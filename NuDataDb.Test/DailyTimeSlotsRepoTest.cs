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
    public class DailyTimeSlotsnRepoTest : BaseUnitTest<DailyTimeSlots>
    {
        Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected DailyTimeSlotsRepo repo;

        protected override void SetContextData()
        {
            repo = new DailyTimeSlotsRepo(testCtx);

            var b = new Faker<DailyTimeSlots>()
                .RuleFor(r => r.TimeSlotId, f => itrtr32++)
                .RuleFor(r => r.TimeSlotBoundary, f => new TimeSpan(f.Random.Long()))
                .RuleFor(r => r.CareSettingsId, f => f.Random.Int())
                .RuleFor(r => r.LastUpdatedByUser, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.TimeSlotId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.DailyTimeSlots.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleDailyTimeSlots()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.TimeSlotId);

            Assert.AreEqual(fakeApp.TimeSlotId, single.TimeSlotId);
            Assert.AreEqual(fakeApp.TimeSlotBoundary, single.TimeSlotBoundary);
        }

        public void GetSingleTimeSlotIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteDailyTimeSlots()
        {
            var currentCnt = testCtx.DailyTimeSlots.Count();

            var entity = testCtx.DailyTimeSlots.First();
            repo.Delete(entity.TimeSlotId);
            repo.Save();

            Assert.IsTrue(testCtx.DailyTimeSlots.Count() == --currentCnt);
        }

        public void DeleteTimeSlotIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
