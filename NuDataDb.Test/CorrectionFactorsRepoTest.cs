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
    public class CorrectionFactorsnRepoTest : BaseUnitTest<CorrectionFactors>
    {
        protected CorrectionFactorsRepo repo;

        protected override void SetContextData()
        {
            repo = new CorrectionFactorsRepo(testCtx);

            var b = new Faker<CorrectionFactors>()
                .RuleFor(r => r.CorrectionFactorValue, f => f.Random.Int())
                .RuleFor(r => r.Date, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)));

            var bs = b.Generate(3).OrderBy(o => o.FactorId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.CorrectionFactors.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleCorrectionFactors()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.FactorId);

            Assert.AreEqual(fakeApp.FactorId, single.FactorId);
            Assert.AreEqual(fakeApp.CorrectionFactorValue, single.CorrectionFactorValue);
        }

        [TestMethod]
        public void GetSingleFactorIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteCorrectionFactors()
        {
            var currentCnt = testCtx.CorrectionFactors.Count();

            var entity = testCtx.CorrectionFactors.First();
            repo.Delete(entity.FactorId);
            repo.Save();

            Assert.IsTrue(testCtx.CorrectionFactors.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteFactorIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 64879;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
