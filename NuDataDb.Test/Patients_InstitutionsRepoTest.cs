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
    public class Patients_InstitutionsnRepoTest : BaseUnitTest<PatientsInstitutions>
    {
        protected PatientsInstitutionsRepo repo;

        protected override void SetContextData()
        {
            repo = new PatientsInstitutionsRepo(testCtx);

            var b = new Faker<PatientsInstitutions>()
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.InstitutionId, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.UserId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.PatientsInstitutions.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSinglePatients_Institutions()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.UserId);

            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.InstitutionId, single.InstitutionId);
        }

        [TestMethod]
        public void GetSingleUserIdNotExist()
        {
            var fakeId = Guid.NewGuid();
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeletePatients_Institutions()
        {
            var currentCnt = testCtx.PatientsInstitutions.Count();

            var entity = testCtx.PatientsInstitutions.First();
            repo.Delete(entity.UserId);
            repo.Save();

            Assert.IsTrue(testCtx.PatientsInstitutions.Count() == --currentCnt);
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
