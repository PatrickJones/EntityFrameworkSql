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
    public class SubscriptionsnRepoTest : BaseUnitTest<NuMedicsGlobalContext,Subscriptions>
    {
        protected SubscriptionsRepo repo;

        protected override void SetContextData()
        {
            repo = new SubscriptionsRepo(testCtx);

            var b = new Faker<Subscriptions>()
                .RuleFor(r => r.ApplicationId, f => f.Random.Uuid())
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.UserType, f => f.Random.Int())
                .RuleFor(r => r.SubscriptionType, f => f.Random.Int())
                .RuleFor(r => r.SubscriptionDate, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)))
                .RuleFor(r => r.ExpirationDate, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)))
                .RuleFor(r => r.IsTrial, f => f.Random.Bool())
                .RuleFor(r => r.InstitutionId, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.SubscriptionId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.Subscriptions.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleSubscriptions()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.SubscriptionId);

            Assert.AreEqual(fakeApp.SubscriptionId, single.SubscriptionId);
            Assert.AreEqual(fakeApp.ApplicationId, single.ApplicationId);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.UserType, single.UserType);
            Assert.AreEqual(fakeApp.SubscriptionType, single.SubscriptionType);
            Assert.AreEqual(fakeApp.SubscriptionDate, single.SubscriptionDate);
            Assert.AreEqual(fakeApp.ExpirationDate, single.ExpirationDate);
            Assert.AreEqual(fakeApp.IsTrial, single.IsTrial);
            Assert.AreEqual(fakeApp.InstitutionId, single.InstitutionId);
        }

        [TestMethod]
        public void GetSingleSubscriptionIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteSubscriptions()
        {
            var currentCnt = testCtx.Subscriptions.Count();

            var entity = testCtx.Subscriptions.First();
            repo.Delete(entity.SubscriptionId);
            repo.Save();

            Assert.IsTrue(testCtx.Subscriptions.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteSubscriptionIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 3498;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
