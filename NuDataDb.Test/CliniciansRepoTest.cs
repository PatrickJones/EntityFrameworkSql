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
    public class CliniciansnRepoTest : BaseUnitTest<Clinicians>
    {
        protected CliniciansRepo repo;

        protected override void SetContextData()
        {
            repo = new CliniciansRepo(testCtx);

            var b = new Faker<Clinicians>()
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.Firstname, f => f.Lorem.Letter(150))
                .RuleFor(r => r.Lastname, f => f.Lorem.Letter(150))
                .RuleFor(r => r.InstitutionId, f => f.Random.Uuid())
                .RuleFor(r => r.InstitutionAddressId, f => f.Random.Int(1,3))
                .RuleFor(r => r.LastUpdatedByUser, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.UserId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.Clinicians.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleClinicians()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.UserId);

            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.Lastname, single.Lastname);
            Assert.AreEqual(fakeApp.Firstname, single.Firstname);
            Assert.AreEqual(fakeApp.InstitutionAddressId, single.InstitutionAddressId);
        }

        [TestMethod]
        public void GetSingleUserIdNotExist()
        {
            var fakeId = Guid.NewGuid();
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteClinicians()
        {
            var currentCnt = testCtx.Clinicians.Count();

            var entity = testCtx.Clinicians.First();
            repo.Delete(entity.UserId);
            repo.Save();

            Assert.IsTrue(testCtx.Clinicians.Count() == --currentCnt);
        }

        [TestMethod]
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
