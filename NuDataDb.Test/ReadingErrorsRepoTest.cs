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
    public class ReadingErrorsnRepoTest : BaseUnitTest<ReadingErrors>
    {
        protected ReadingErrorsRepo repo;

        protected override void SetContextData()
        {
            repo = new ReadingErrorsRepo(testCtx);

            var b = new Faker<ReadingErrors>()
                .RuleFor(r => r.Time, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)))
                .RuleFor(r => r.ErrorName, f => f.Lorem.Letter(50))
                .RuleFor(r => r.IsActive, f => f.Random.Bool())
                .RuleFor(r => r.ReadingKeyId, f => f.Random.Uuid())
                .RuleFor(r => r.UserId, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.ErrorId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.ReadingErrors.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleReadingErrors()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.ErrorId);

            Assert.AreEqual(fakeApp.ErrorId, single.ErrorId);
            Assert.AreEqual(fakeApp.Time, single.Time);
            Assert.AreEqual(fakeApp.ErrorName, single.ErrorName);
            Assert.AreEqual(fakeApp.IsActive, single.IsActive);
            Assert.AreEqual(fakeApp.ReadingKeyId, single.ReadingKeyId);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
        }

        [TestMethod]
        public void GetSingleErrorIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteReadingErrors()
        {
            var currentCnt = testCtx.ReadingErrors.Count();

            var entity = testCtx.ReadingErrors.First();
            repo.Delete(entity.ErrorId);
            repo.Save();

            Assert.IsTrue(testCtx.ReadingErrors.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteErrorIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 567;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
