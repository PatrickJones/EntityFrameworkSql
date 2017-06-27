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
    public class BasalDeliveryDatanRepoTest : BaseUnitTest<BasalDeliveryData>
    {
        //Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected BasalDeliveryDataRepo repo;

        protected override void SetContextData()
        {
            repo = new BasalDeliveryDataRepo(testCtx);

            var b = new Faker<BasalDeliveryData>()
                .RuleFor(r => r.DataId, f => itrtr32++)
                .RuleFor(r => r.Name, f => f.Lorem.Random.AlphaNumeric(150))
                .RuleFor(r => r.Value, f => f.Lorem.Random.AlphaNumeric(150))
                .RuleFor(r => r.BasalDeliveryId, f => f.Lorem.Random.Int())
                .RuleFor(r => r.Date, f => DateTime.Now);

            var bs = b.Generate(3).OrderBy(o => o.DataId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.BasalDeliveryData.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleBasalDeliveryData()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.DataId);

            Assert.AreEqual(fakeApp.DataId, single.DataId);
            Assert.AreEqual(fakeApp.Name, single.Name);
        }

        public void GetSingleDataIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteBasalDeliveryData()
        {
            var currentCnt = testCtx.BasalDeliveryData.Count();

            var entity = testCtx.BasalDeliveryData.First();
            repo.Delete(entity.DataId);
            repo.Save();

            Assert.IsTrue(testCtx.BasalDeliveryData.Count() == --currentCnt);
        }

        public void DeleteDataIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
