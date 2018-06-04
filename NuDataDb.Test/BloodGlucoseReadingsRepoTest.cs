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
    public class BloodGlucoseReadingsnRepoTest : BaseUnitTest<NuMedicsGlobalContext,BloodGlucoseReadings>
    {
        protected BloodGlucoseReadingsRepo repo;

        protected override void SetContextData()
        {
            repo = new BloodGlucoseReadingsRepo(testCtx);

            var b = new Faker<BloodGlucoseReadings>()
                .RuleFor(r => r.ReadingDateTime, f => DateTime.Now)
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.Active, f => f.Random.Bool())
                .RuleFor(r => r.ReadingKeyId, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.ReadingId).ToList();
            testCtx.BloodGlucoseReadings.AddRange(bs);
            FakeCollection.AddRange(bs);

            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleBloodGlucoseReadings()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.ReadingId);

            Assert.AreEqual(fakeApp.ReadingId, single.ReadingId);
            Assert.AreEqual(fakeApp.ReadingDateTime, single.ReadingDateTime);
        }

        [TestMethod]
        public void GetSingleReadingIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteBloodGlucoseReadings()
        {
            var currentCnt = testCtx.BloodGlucoseReadings.Count();

            var entity = testCtx.BloodGlucoseReadings.First();
            repo.Delete(entity.ReadingId);
            repo.Save();

            Assert.IsTrue(testCtx.BloodGlucoseReadings.Count() == --currentCnt);
        }

        public void DeleteReadingIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 319;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
