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
    public class TensReadingsnRepoTest : BaseUnitTest<TensReadings>
    {
        protected TensReadingsRepo repo;

        protected override void SetContextData()
        {
            repo = new TensReadingsRepo(testCtx);

            var b = new Faker<TensReadings>()
                .RuleFor(r => r.ReadingDate, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)))
                .RuleFor(r => r.TherapyType, f => f.Random.Int())
                .RuleFor(r => r.DurationScheduled, f => f.Random.Int())
                .RuleFor(r => r.DurationCompleted, f => f.Random.Int())
                //.RuleFor(r => r.Intensity, f => f.Lorem.Letter(50))
                .RuleFor(r => r.ReadingKeyId, f => f.Random.Uuid())
                .RuleFor(r => r.UserId, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.ReadingId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.TensReadings.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleTensReadings()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.ReadingId);

            Assert.AreEqual(fakeApp.ReadingId, single.ReadingId);
            Assert.AreEqual(fakeApp.ReadingDate, single.ReadingDate);
            Assert.AreEqual(fakeApp.TherapyType, single.TherapyType);
            Assert.AreEqual(fakeApp.DurationScheduled, single.DurationScheduled);
            Assert.AreEqual(fakeApp.DurationCompleted, single.DurationCompleted);
            //Assert.AreEqual(fakeApp.Intensity, single.Intensity);
            Assert.AreEqual(fakeApp.ReadingKeyId, single.ReadingKeyId);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
        }

        [TestMethod]
        public void GetSingleReadingIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteTensReadings()
        {
            var currentCnt = testCtx.TensReadings.Count();

            var entity = testCtx.TensReadings.First();
            repo.Delete(entity.ReadingId);
            repo.Save();

            Assert.IsTrue(testCtx.TensReadings.Count() == --currentCnt);
        }

        [TestMethod]
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
