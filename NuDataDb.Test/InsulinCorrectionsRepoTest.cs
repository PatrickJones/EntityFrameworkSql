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
    public class InsulinCorrectionsnRepoTest : BaseUnitTest<InsulinCorrections>
    {
        protected InsulinCorrectionsRepo repo;

        protected override void SetContextData()
        {
            repo = new InsulinCorrectionsRepo(testCtx);

            var b = new Faker<InsulinCorrections>()
                .RuleFor(r => r.InsulinCorrectionValue, f => f.Random.Int())
                .RuleFor(r => r.Date, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)))
                .RuleFor(r => r.InsulinCorrectionAbove, f => f.Random.Int());

            var bs = b.Generate(3).OrderBy(o => o.CorrectionId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.InsulinCorrections.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleInsulinCorrections()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.CorrectionId);

            Assert.AreEqual(fakeApp.CorrectionId, single.CorrectionId);
            Assert.AreEqual(fakeApp.InsulinCorrectionValue, single.InsulinCorrectionValue);
            Assert.AreEqual(fakeApp.Date, single.Date);
            Assert.AreEqual(fakeApp.InsulinCorrectionAbove, single.InsulinCorrectionAbove);
        }

        [TestMethod]
        public void GetSingleCorrectionIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteInsulinCorrections()
        {
            var currentCnt = testCtx.InsulinCorrections.Count();

            var entity = testCtx.InsulinCorrections.First();
            repo.Delete(entity.CorrectionId);
            repo.Save();

            Assert.IsTrue(testCtx.InsulinCorrections.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteCorrectionIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 974;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
