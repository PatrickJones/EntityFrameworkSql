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
    public class BasalProgramTimeSlotsnRepoTest : BaseUnitTest<NuMedicsGlobalContext,ProgramTimeSlots>
    {
        //Int64 itrtr64 = 0;
        //int itrtr32 = 0;

        protected ProgramTimeSlotsRepo repo;

        protected override void SetContextData()
        {
            repo = new ProgramTimeSlotsRepo(testCtx);

            var b = new Faker<ProgramTimeSlots>()
                //.RuleFor(r => r.BasalSlotId, f => itrtr32++)
                .RuleFor(r => r.Value, f => f.Random.Float())
                .RuleFor(r => r.StartTime, f => DateTime.Now - new DateTime(2017, 3, 5))
                .RuleFor(r => r.StopTime, f => DateTime.Now - new DateTime(2017, 5, 3))
                .RuleFor(r => r.PumpProgramId, f => f.Random.Int())
                .RuleFor(r => r.DateSet, f => DateTime.Now);

            var bs = b.Generate(3).OrderBy(o => o.SlotId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.BasalProgramTimeSlots.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleBasalProgramTimeSlots()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.SlotId);

            Assert.AreEqual(fakeApp.SlotId, single.SlotId);
            Assert.AreEqual(fakeApp.Value, single.Value);
        }

        [TestMethod]
        public void GetSingleBasalSlotIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }

        [TestMethod]
        public void DeleteBasalProgramTimeSlots()
        {
            var currentCnt = testCtx.BasalProgramTimeSlots.Count();

            var entity = testCtx.BasalProgramTimeSlots.First();
            repo.Delete(entity.SlotId);
            repo.Save();

            Assert.IsTrue(testCtx.BasalProgramTimeSlots.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteBasalSlotIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 246;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
