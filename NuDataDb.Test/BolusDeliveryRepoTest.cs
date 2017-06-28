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
    public class BolusDeliverynRepoTest : BaseUnitTest<BolusDelivery>
    {
        protected BolusDeliveryRepo repo;

        protected override void SetContextData()
        {
            repo = new BolusDeliveryRepo(testCtx);

            var b = new Faker<BolusDelivery>()
                .RuleFor(r => r.StartDateTime, f => DateTime.Now)
                .RuleFor(r => r.AmountDelivered, f => f.Random.Double())
                .RuleFor(r => r.AmountSuggested, f => f.Random.Double())
                .RuleFor(r => r.Duration, f => f.Random.Int())
                .RuleFor(r => r.ReadingKeyId, f => f.Random.Uuid())
                .RuleFor(r => r.UserId, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.BolusDeliveryId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.BolusDelivery.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleBolusDelivery()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.BolusDeliveryId);

            Assert.AreEqual(fakeApp.BolusDeliveryId, single.BolusDeliveryId);
            Assert.AreEqual(fakeApp.AmountDelivered, single.AmountDelivered);
        }

        [TestMethod]
        public void GetSingleBolusDeliveryIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteBolusDelivery()
        {
            var currentCnt = testCtx.BolusDelivery.Count();

            var entity = testCtx.BolusDelivery.First();
            repo.Delete(entity.BolusDeliveryId);
            repo.Save();

            Assert.IsTrue(testCtx.BolusDelivery.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteBolusDeliveryIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 7946;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
