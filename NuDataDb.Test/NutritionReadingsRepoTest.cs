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
    public class NutritionReadingsnRepoTest : BaseUnitTest<NutritionReadings>
    {
        //Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected NutritionReadingsRepo repo;

        protected override void SetContextData()
        {
            repo = new NutritionReadingsRepo(testCtx);

            var b = new Faker<NutritionReadings>()
                .RuleFor(r => r.ReadingId, f => itrtr32++)
                .RuleFor(r => r.Carbohydrates, f => f.Random.Float())
                .RuleFor(r => r.Calories, f => f.Random.Float())
                .RuleFor(r => r.Protien, f => f.Random.Float())
                .RuleFor(r => r.Fat, f => f.Random.Float())
                .RuleFor(r => r.ReadingDateTime, f => new DateTime(f.Random.Long()))
                .RuleFor(r => r.ReadingKeyId, f => f.Random.Uuid())
                .RuleFor(r => r.UserId, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.ReadingId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.NutritionReadings.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleNutritionReadings()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.ReadingId);

            Assert.AreEqual(fakeApp.ReadingId, single.ReadingId);
            Assert.AreEqual(fakeApp.Carbohydrates, single.Carbohydrates);
            Assert.AreEqual(fakeApp.Calories, single.Calories);
            Assert.AreEqual(fakeApp.Protien, single.Protien);
            Assert.AreEqual(fakeApp.Fat, single.Fat);
            Assert.AreEqual(fakeApp.ReadingDateTime, single.ReadingDateTime);
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
        public void DeleteNutritionReadings()
        {
            var currentCnt = testCtx.NutritionReadings.Count();

            var entity = testCtx.NutritionReadings.First();
            repo.Delete(entity.ReadingId);
            repo.Save();

            Assert.IsTrue(testCtx.NutritionReadings.Count() == --currentCnt);
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
