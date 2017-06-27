using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuDataDb.EF;
using NuDataDb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Test
{
    [TestClass]
    public class PatientsnRepoTest : BaseUnitTest<Patients>
    {
        Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected PatientsRepo repo;

        protected override void SetContextData()
        {
            repo = new PatientsRepo(testCtx);

            var b = new Faker<Patients>()
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.Firstname, f => f.Lorem.Letter(80))
                .RuleFor(r => r.Lastname, f => f.Lorem.Letter(80))
                .RuleFor(r => r.Gender, f => f.Random.Int())
                .RuleFor(r => r.DateofBirth, f => new DateTime(f.Random.Long()))
                .RuleFor(r => r.PlanId, f => f.Random.Int())
                .RuleFor(r => r.Email, f => f.Lorem.Letter(150))
                .RuleFor(r => r.InstitutionId, f => f.Random.Uuid())
                .RuleFor(r => r.LastUpdatedByUser, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.UserId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.Patients.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSinglePatients()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.UserId);

            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.Firstname, single.Firstname);
            Assert.AreEqual(fakeApp.Lastname, single.Lastname);
            Assert.AreEqual(fakeApp.Gender, single.Gender);
            Assert.AreEqual(fakeApp.DateofBirth, single.DateofBirth);
            Assert.AreEqual(fakeApp.PlanId, single.PlanId);
            Assert.AreEqual(fakeApp.Email, single.Email);
            Assert.AreEqual(fakeApp.InstitutionId, single.InstitutionId);
            Assert.AreEqual(fakeApp.LastUpdatedByUser, single.LastUpdatedByUser);
        }

        public void GetSingleUserIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeletePatients()
        {
            var currentCnt = testCtx.Patients.Count();

            var entity = testCtx.Patients.First();
            repo.Delete(entity.UserId);
            repo.Save();

            Assert.IsTrue(testCtx.Patients.Count() == --currentCnt);
        }

        public void DeleteUserIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = Guid.NewGuid();
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
