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
    public class ReadingEventsnRepoTest : BaseUnitTest<ReadingEvents>
    {
        //Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected ReadingEventsRepo repo;

        protected override void SetContextData()
        {
            repo = new ReadingEventsRepo(testCtx);

            var b = new Faker<ReadingEvents>()
                .RuleFor(r => r.Eventid, f => itrtr32++)
                .RuleFor(r => r.EventType, f => f.Random.Int())
                .RuleFor(r => r.EventValue, f => f.Lorem.Letter(150))
                .RuleFor(r => r.EventTime, f => new DateTime(f.Random.Long()))
                .RuleFor(r => r.StartTime, f => new DateTime(f.Random.Long()))
                .RuleFor(r => r.ResumeTime, f => new DateTime(f.Random.Long()))
                .RuleFor(r => r.StopTime, f => new DateTime(f.Random.Long()))
                .RuleFor(r => r.ReadingKeyId, f => f.Random.Uuid())
                .RuleFor(r => r.UserId, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.Eventid).ToList();
            FakeCollection.AddRange(bs);


            testCtx.ReadingEvents.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleReadingEvents()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.Eventid);

            Assert.AreEqual(fakeApp.Eventid, single.Eventid);
            Assert.AreEqual(fakeApp.EventType, single.EventType);
            Assert.AreEqual(fakeApp.EventValue, single.EventValue);
            Assert.AreEqual(fakeApp.EventTime, single.EventTime);
            Assert.AreEqual(fakeApp.StartTime, single.StartTime);
            Assert.AreEqual(fakeApp.ResumeTime, single.ResumeTime);
            Assert.AreEqual(fakeApp.StopTime, single.StopTime);
            Assert.AreEqual(fakeApp.ReadingKeyId, single.ReadingKeyId);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
        }

        public void GetSingleEventidNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteReadingEvents()
        {
            var currentCnt = testCtx.ReadingEvents.Count();

            var entity = testCtx.ReadingEvents.First();
            repo.Delete(entity.Eventid);
            repo.Save();

            Assert.IsTrue(testCtx.ReadingEvents.Count() == --currentCnt);
        }

        public void DeleteEventidNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
