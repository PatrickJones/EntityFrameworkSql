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
    public class SubscriptionTypenRepoTest : BaseUnitTest<SubscriptionType>
    {
        protected SubscriptionTypeRepo repo;

        protected override void SetContextData()
        {
            repo = new SubscriptionTypeRepo(testCtx);

            var b = new Faker<SubscriptionType>()
                .RuleFor(r => r.ApplicationId, f => f.Random.Uuid())
                .RuleFor(r => r.SubscriptionLengthDays, f => f.Random.Int())
                .RuleFor(r => r.Price, f => f.Random.Decimal());

            var bs = b.Generate(3).OrderBy(o => o.SubscriptionTypeId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.SubscriptionType.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleSubscriptionType()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.SubscriptionTypeId);

            Assert.AreEqual(fakeApp.SubscriptionTypeId, single.SubscriptionTypeId);
            Assert.AreEqual(fakeApp.ApplicationId, single.ApplicationId);
            Assert.AreEqual(fakeApp.SubscriptionLengthDays, single.SubscriptionLengthDays);
            Assert.AreEqual(fakeApp.Price, single.Price);
        }

        [TestMethod]
        public void GetSingleSubscriptionTypeIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteSubscriptionType()
        {
            var currentCnt = testCtx.SubscriptionType.Count();

            var entity = testCtx.SubscriptionType.First();
            repo.Delete(entity.SubscriptionTypeId);
            repo.Save();

            Assert.IsTrue(testCtx.SubscriptionType.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteSubscriptionTypeIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 169;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
