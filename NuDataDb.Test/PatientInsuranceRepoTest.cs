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
    public class InsurancePlansnRepoTest : BaseUnitTest<NuMedicsGlobalContext, PatientInsurance>
    {
        protected PatientInsuranceRepo repo;

        protected override void SetContextData()
        {
            repo = new PatientInsuranceRepo(testCtx);

            var b = new Faker<PatientInsurance>()
                .RuleFor(r => r.ProviderName, f => f.Company.CompanyName())
                .RuleFor(r => r.PolicyNumber, f => f.Random.Int(1, 150).ToString())
                .RuleFor(r => r.PlanIdentifier, f => f.Lorem.Word())
                .RuleFor(r => r.GroupIdentifier, f => f.Lorem.Word())
                .RuleFor(r => r.UserId, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.PatientInsuranceId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.PatientInsurance.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleInsurancePlans()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.PatientInsuranceId);

            Assert.AreEqual(fakeApp.PatientInsuranceId, single.PatientInsuranceId);
            Assert.AreEqual(fakeApp.ProviderName, single.ProviderName);
            Assert.AreEqual(fakeApp.PolicyNumber, single.PolicyNumber);
            Assert.AreEqual(fakeApp.PlanIdentifier, single.PlanIdentifier);
            Assert.AreEqual(fakeApp.GroupIdentifier, single.GroupIdentifier);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
        }

        [TestMethod]
        public void GetSinglePlanIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteInsurancePlans()
        {
            var currentCnt = testCtx.PatientInsurance.Count();

            var entity = testCtx.PatientInsurance.First();
            repo.Delete(entity.PatientInsuranceId);
            repo.Save();

            Assert.IsTrue(testCtx.PatientInsurance.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeletePlanIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 584;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
