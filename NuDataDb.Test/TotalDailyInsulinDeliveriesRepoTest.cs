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
    public class TotalDailyInsulinDeliveriesnRepoTest : BaseUnitTest<TotalDailyInsulinDeliveries>
    {
        protected TotalDailyInsulinDeliveriesRepo repo;

        protected override void SetContextData()
        {
            repo = new TotalDailyInsulinDeliveriesRepo(testCtx);

            var b = new Faker<TotalDailyInsulinDeliveries>()
                .RuleFor(r => r.TotalDelivered, f => f.Random.Float())
                .RuleFor(r => r.BasalDelivered, f => f.Random.Float())
                .RuleFor(r => r.TempActivated, f => f.Random.Bool())
                .RuleFor(r => r.Valid, f => f.Random.Bool())
                .RuleFor(r => r.BolusDelivered, f => f.Random.Float())
                .RuleFor(r => r.ReadingKeyId, f => f.Random.Uuid())
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.Date, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)));

            var bs = b.Generate(3).OrderBy(o => o.DeliveryId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.TotalDailyInsulinDeliveries.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleTotalDailyInsulinDeliveries()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.DeliveryId);

            Assert.AreEqual(fakeApp.DeliveryId, single.DeliveryId);
            Assert.AreEqual(fakeApp.TotalDelivered, single.TotalDelivered);
            Assert.AreEqual(fakeApp.BasalDelivered, single.BasalDelivered);
            Assert.AreEqual(fakeApp.TempActivated, single.TempActivated);
            Assert.AreEqual(fakeApp.Valid, single.Valid);
            Assert.AreEqual(fakeApp.BolusDelivered, single.BolusDelivered);
            Assert.AreEqual(fakeApp.ReadingKeyId, single.ReadingKeyId);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.Date, single.Date);
        }

        [TestMethod]
        public void GetSingleDeliveryIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteTotalDailyInsulinDeliveries()
        {
            var currentCnt = testCtx.TotalDailyInsulinDeliveries.Count();

            var entity = testCtx.TotalDailyInsulinDeliveries.First();
            repo.Delete(entity.DeliveryId);
            repo.Save();

            Assert.IsTrue(testCtx.TotalDailyInsulinDeliveries.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteDeliveryIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 1348;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
