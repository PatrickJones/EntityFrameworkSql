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
    public class ReadingEventTypesnRepoTest : BaseUnitTest<NuMedicsGlobalContext,ReadingEventTypes>
    {
        protected ReadingEventTypesRepo repo;

        protected override void SetContextData()
        {
            repo = new ReadingEventTypesRepo(testCtx);

            var b = new Faker<ReadingEventTypes>()
                .RuleFor(r => r.EventName, f => f.Lorem.Letter(150));

            var bs = b.Generate(3).OrderBy(o => o.EventId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.ReadingEventTypes.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleReadingEventTypes()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.EventId);

            Assert.AreEqual(fakeApp.EventId, single.EventId);
            Assert.AreEqual(fakeApp.EventName, single.EventName);
        }

        [TestMethod]
        public void GetSingleEventIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteReadingEventTypes()
        {
            var currentCnt = testCtx.ReadingEventTypes.Count();

            var entity = testCtx.ReadingEventTypes.First();
            repo.Delete(entity.EventId);
            repo.Save();

            Assert.IsTrue(testCtx.ReadingEventTypes.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteEventIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 137;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
