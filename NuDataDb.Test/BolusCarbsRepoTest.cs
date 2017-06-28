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
    public class BolusCarbsnRepoTest : BaseUnitTest<BolusCarbs>
    {
        protected BolusCarbsRepo repo;

        protected override void SetContextData()
        {
            repo = new BolusCarbsRepo(testCtx);

            var b = new Faker<BolusCarbs>()
                .RuleFor(r => r.CarbValue, f => f.Random.Int())
                .RuleFor(r => r.Date, f => DateTime.Now);

            var bs = b.Generate(3).OrderBy(o => o.CarbId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.BolusCarbs.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleBolusCarbs()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.CarbId);

            Assert.AreEqual(fakeApp.CarbId, single.CarbId);
            Assert.AreEqual(fakeApp.CarbValue, single.CarbValue);
        }

        [TestMethod]
        public void GetSingleCarbIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteBolusCarbs()
        {
            var currentCnt = testCtx.BolusCarbs.Count();

            var entity = testCtx.BolusCarbs.First();
            repo.Delete(entity.CarbId);
            repo.Save();

            Assert.IsTrue(testCtx.BolusCarbs.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteCarbIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 512;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
