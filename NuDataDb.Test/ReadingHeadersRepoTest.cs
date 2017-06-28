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
    public class ReadingHeadersnRepoTest : BaseUnitTest<ReadingHeaders>
    {
        protected ReadingHeadersRepo repo;

        protected override void SetContextData()
        {
            repo = new ReadingHeadersRepo(testCtx);

            var b = new Faker<ReadingHeaders>()
                .RuleFor(r => r.ReadingKeyId, f => f.Random.Uuid())
                .RuleFor(r => r.ServerDateTime, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)))
                .RuleFor(r => r.MeterDateTime, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)))
                .RuleFor(r => r.Readings, f => f.Random.Int())
                .RuleFor(r => r.ReviewedOn, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)))
                .RuleFor(r => r.IsCgmdata, f => f.Random.Bool())
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.ReadingKeyId, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.ReadingKeyId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.ReadingHeaders.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleReadingHeaders()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.ReadingKeyId);

            Assert.AreEqual(fakeApp.ReadingKeyId, single.ReadingKeyId);
            Assert.AreEqual(fakeApp.ServerDateTime, single.ServerDateTime);
            Assert.AreEqual(fakeApp.MeterDateTime, single.MeterDateTime);
            Assert.AreEqual(fakeApp.Readings, single.Readings);
            Assert.AreEqual(fakeApp.ReviewedOn, single.ReviewedOn);
            Assert.AreEqual(fakeApp.IsCgmdata, single.IsCgmdata);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.ReadingKeyId, single.ReadingKeyId);
        }

        [TestMethod]
        public void GetSingleReadingKeyIdNotExist()
        {
            var fakeId = Guid.NewGuid();
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteReadingHeaders()
        {
            var currentCnt = testCtx.ReadingHeaders.Count();

            var entity = testCtx.ReadingHeaders.First();
            repo.Delete(entity.ReadingKeyId);
            repo.Save();

            Assert.IsTrue(testCtx.ReadingHeaders.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteReadingKeyIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = Guid.NewGuid();
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
