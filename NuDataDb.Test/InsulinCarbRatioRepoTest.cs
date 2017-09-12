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
    public class InsulinCarbRationRepoTest : BaseUnitTest<NuMedicsGlobalContext,InsulinCarbRatio>
    {
        protected InsulinCarbRatioRepo repo;

        protected override void SetContextData()
        {
            repo = new InsulinCarbRatioRepo(testCtx);

            var b = new Faker<InsulinCarbRatio>()
                .RuleFor(r => r.Icratio, f => f.Random.Int())
                .RuleFor(r => r.Date, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)));

            var bs = b.Generate(3).OrderBy(o => o.RatioId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.InsulinCarbRatio.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleInsulinCarbRatio()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.RatioId);

            Assert.AreEqual(fakeApp.RatioId, single.RatioId);
            Assert.AreEqual(fakeApp.Icratio, single.Icratio);
            Assert.AreEqual(fakeApp.Date, single.Date);
        }

        [TestMethod]
        public void GetSingleRatioIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }

        [TestMethod]
        public void DeleteInsulinCarbRatio()
        {
            var currentCnt = testCtx.InsulinCarbRatio.Count();

            var entity = testCtx.InsulinCarbRatio.First();
            repo.Delete(entity.RatioId);
            repo.Save();

            Assert.IsTrue(testCtx.InsulinCarbRatio.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteRatioIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 654;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
