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
    public class BolusProgramTimeSlotsnRepoTest : BaseUnitTest<BolusProgramTimeSlots>
    {
        protected BolusProgramTimeSlotsRepo repo;

        protected override void SetContextData()
        {
            repo = new BolusProgramTimeSlotsRepo(testCtx);

            var b = new Faker<BolusProgramTimeSlots>()
                .RuleFor(r => r.BolusValue, f => f.Random.Double())
                .RuleFor(r => r.StartTime, f => new TimeSpan(f.Random.Long()))
                .RuleFor(r => r.StopTime, f => new TimeSpan(f.Random.Long()))
                .RuleFor(r => r.PumpProgramId, f => f.Random.Int())
                .RuleFor(r => r.DateSet, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)));

            var bs = b.Generate(3).OrderBy(o => o.BolusSlotId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.BolusProgramTimeSlots.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleBolusProgramTimeSlots()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.BolusSlotId);

            Assert.AreEqual(fakeApp.BolusSlotId, single.BolusSlotId);
            Assert.AreEqual(fakeApp.BolusValue, single.BolusValue);
        }

        [TestMethod]
        public void GetSingleBolusSlotIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }

        [TestMethod]
        public void DeleteBolusProgramTimeSlots()
        {
            var currentCnt = testCtx.BolusProgramTimeSlots.Count();

            var entity = testCtx.BolusProgramTimeSlots.First();
            repo.Delete(entity.BolusSlotId);
            repo.Save();

            Assert.IsTrue(testCtx.BolusProgramTimeSlots.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteBolusSlotIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 5649;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
