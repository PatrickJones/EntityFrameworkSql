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
    public class PhysiologicalReadingsnRepoTest : BaseUnitTest<PhysiologicalReadings>
    {
        //Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected PhysiologicalReadingsRepo repo;

        protected override void SetContextData()
        {
            repo = new PhysiologicalReadingsRepo(testCtx);

            var b = new Faker<PhysiologicalReadings>()
                .RuleFor(r => r.ReadingId, f => itrtr32++)
                .RuleFor(r => r.Time, f => new DateTime(f.Random.Long()))
                .RuleFor(r => r.Weight, f => f.Random.Int())
                //.RuleFor(r => r.Height, f => f.Random.Int())
                .RuleFor(r => r.Hunger, f => f.Random.Int())
                .RuleFor(r => r.Nausea, f => f.Random.Int())
                .RuleFor(r => r.CaloriesBurned, f => f.Random.Int())
                .RuleFor(r => r.CaloriesConsumed, f => f.Random.Int())
                .RuleFor(r => r.ReadingKeyId, f => f.Random.Uuid())
                .RuleFor(r => r.UserId, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.ReadingId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.PhysiologicalReadings.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSinglePhysiologicalReadings()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.ReadingId);

            Assert.AreEqual(fakeApp.ReadingId, single.ReadingId);
            Assert.AreEqual(fakeApp.Time, single.Time);
            Assert.AreEqual(fakeApp.Weight, single.Weight);
            //Assert.AreEqual(fakeApp.Height, single.Height);
            Assert.AreEqual(fakeApp.Hunger, single.Hunger);
            Assert.AreEqual(fakeApp.Nausea, single.Nausea);
            Assert.AreEqual(fakeApp.CaloriesBurned, single.CaloriesBurned);
            Assert.AreEqual(fakeApp.CaloriesConsumed, single.CaloriesConsumed);
            Assert.AreEqual(fakeApp.ReadingKeyId, single.ReadingKeyId);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
        }

        public void GetSingleReadingIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeletePhysiologicalReadings()
        {
            var currentCnt = testCtx.PhysiologicalReadings.Count();

            var entity = testCtx.PhysiologicalReadings.First();
            repo.Delete(entity.ReadingId);
            repo.Save();

            Assert.IsTrue(testCtx.PhysiologicalReadings.Count() == --currentCnt);
        }

        public void DeleteReadingIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
