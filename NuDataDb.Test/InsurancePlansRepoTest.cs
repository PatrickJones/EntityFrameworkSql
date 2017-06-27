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
    public class InsurancePlansnRepoTest : BaseUnitTest<InsurancePlans>
    {
        //Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected InsurancePlansRepo repo;

        protected override void SetContextData()
        {
            repo = new InsurancePlansRepo(testCtx);

            var b = new Faker<InsurancePlans>()
                .RuleFor(r => r.PlanId, f => itrtr32++)
                .RuleFor(r => r.CoPay, f => f.Random.Decimal())
                .RuleFor(r => r.IsActive, f => f.Random.Bool())
                .RuleFor(r => r.InActiveDate, f => new DateTime(f.Random.Long()))
                .RuleFor(r => r.EffectiveDate, f => new DateTime(f.Random.Long()))
                .RuleFor(r => r.PlanName, f => f.Lorem.Letter(150))
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.LastUpdatedByUser, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.PlanId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.InsurancePlans.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleInsurancePlans()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.PlanId);

            Assert.AreEqual(fakeApp.PlanId, single.PlanId);
            Assert.AreEqual(fakeApp.CoPay, single.CoPay);
            Assert.AreEqual(fakeApp.IsActive, single.IsActive);
            Assert.AreEqual(fakeApp.InActiveDate, single.InActiveDate);
            Assert.AreEqual(fakeApp.EffectiveDate, single.EffectiveDate);
            Assert.AreEqual(fakeApp.PlanName, single.PlanName);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.LastUpdatedByUser, single.LastUpdatedByUser);
        }

        public void GetSinglePlanIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteInsurancePlans()
        {
            var currentCnt = testCtx.InsurancePlans.Count();

            var entity = testCtx.InsurancePlans.First();
            repo.Delete(entity.PlanId);
            repo.Save();

            Assert.IsTrue(testCtx.InsurancePlans.Count() == --currentCnt);
        }

        public void DeletePlanIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
