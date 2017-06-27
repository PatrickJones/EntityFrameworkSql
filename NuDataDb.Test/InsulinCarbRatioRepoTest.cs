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
    public class InsulinCarbRationRepoTest : BaseUnitTest<InsulinCarbRatio>
    {
        //Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected InsulinCarbRatioRepo repo;

        protected override void SetContextData()
        {
            repo = new InsulinCarbRatioRepo(testCtx);

            var b = new Faker<InsulinCarbRatio>()
                .RuleFor(r => r.RatioId, f => itrtr32++)
                .RuleFor(r => r.Icratio, f => f.Random.Int())
                .RuleFor(r => r.Date, f => new DateTime(f.Random.Long()));

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

        public void DeleteRatioIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
