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
    public class Patients_InsurancePlansnRepoTest : BaseUnitTest<PatientsInsurancePlans>
    {
        protected PatientsInsurancePlansRepo repo;

        protected override void SetContextData()
        {
            repo = new PatientsInsurancePlansRepo(testCtx);

            var b = new Faker<PatientsInsurancePlans>()
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.PlanId, f => f.Random.Int());

            var bs = b.Generate(3).OrderBy(o => o.UserId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.PatientsInsurancePlans.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSinglePatients_InsurancePlans()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.UserId);

            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.PlanId, single.PlanId);
        }

        [TestMethod]
        public void GetSingleUserIdNotExist()
        {
            var fakeId = Guid.NewGuid();
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeletePatients_InsurancePlans()
        {
            var currentCnt = testCtx.PatientsInsurancePlans.Count();

            var entity = testCtx.PatientsInsurancePlans.First();
            repo.Delete(entity.UserId);
            repo.Save();

            Assert.IsTrue(testCtx.PatientsInsurancePlans.Count() == --currentCnt);
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
