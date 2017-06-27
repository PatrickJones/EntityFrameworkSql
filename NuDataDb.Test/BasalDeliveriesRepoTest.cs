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
    public class BasalDeliveriesnRepoTest : BaseUnitTest<BasalDeliveries>
    {
        //Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected BasalDeliveriesRepo repo;

        protected override void SetContextData()
        {
            repo = new BasalDeliveriesRepo(testCtx);

            var b = new Faker<BasalDeliveries>()
                .RuleFor(r => r.BasalDeliveryId, f => itrtr32++)
                .RuleFor(r => r.AmountDelivered, f => f.Random.Int())
                .RuleFor(r => r.DeliveryRate, f => f.Random.Float())
                .RuleFor(r => r.IsTemp, f => f.Random.Bool())
                .RuleFor(r => r.Duration, f => f.Lorem.Word())
                .RuleFor(r => r.StartDateTime, f => DateTime.Now);

            var bs = b.Generate(3).OrderBy(o => o.BasalDeliveryId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.BasalDeliveries.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleBasalDeliveries()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.BasalDeliveryId);

            Assert.AreEqual(fakeApp.BasalDeliveryId, single.BasalDeliveryId);
            Assert.AreEqual(fakeApp.AmountDelivered, single.AmountDelivered);
        }

        public void GetSingleBasalDeliveryIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteBasalDeliveries()
        {
            var currentCnt = testCtx.BasalDeliveries.Count();

            var entity = testCtx.BasalDeliveries.First();
            repo.Delete(entity.BasalDeliveryId);
            repo.Save();

            Assert.IsTrue(testCtx.BasalDeliveries.Count() == --currentCnt);
        }

        public void DeleteBasalDeliveryIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
