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
    public class BasalProgramTimeSlotsnRepoTest : BaseUnitTest<NuMedicsGlobalContext,BasalProgramTimeSlots>
    {
        //Int64 itrtr64 = 0;
        //int itrtr32 = 0;

        protected BasalProgramTimeSlotsRepo repo;

        protected override void SetContextData()
        {
            repo = new BasalProgramTimeSlotsRepo(testCtx);

            var b = new Faker<BasalProgramTimeSlots>()
                //.RuleFor(r => r.BasalSlotId, f => itrtr32++)
                .RuleFor(r => r.BasalValue, f => f.Random.Float())
                .RuleFor(r => r.StartTime, f => DateTime.Now - new DateTime(2017, 3, 5))
                .RuleFor(r => r.StopTime, f => DateTime.Now - new DateTime(2017, 5, 3))
                .RuleFor(r => r.PumpProgramId, f => f.Random.Int())
                .RuleFor(r => r.DateSet, f => DateTime.Now);

            var bs = b.Generate(3).OrderBy(o => o.BasalSlotId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.BasalProgramTimeSlots.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleBasalProgramTimeSlots()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.BasalSlotId);

            Assert.AreEqual(fakeApp.BasalSlotId, single.BasalSlotId);
            Assert.AreEqual(fakeApp.BasalValue, single.BasalValue);
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
            repo.Delete(entity.BasalSlotId);
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
