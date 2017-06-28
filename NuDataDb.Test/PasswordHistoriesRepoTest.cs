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
    public class PasswordHistoriesnRepoTest : BaseUnitTest<PasswordHistories>
    {
        protected PasswordHistoriesRepo repo;

        protected override void SetContextData()
        {
            repo = new PasswordHistoriesRepo(testCtx);

            var b = new Faker<PasswordHistories>()
                .RuleFor(r => r.Password, f => f.Lorem.Letter(150))
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.LastDateUsed, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)))
                .RuleFor(r => r.AuthenticationId, f => f.Random.Int());

            var bs = b.Generate(3).OrderBy(o => o.HistoryId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.PasswordHistories.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSinglePasswordHistories()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.HistoryId);

            Assert.AreEqual(fakeApp.HistoryId, single.HistoryId);
            Assert.AreEqual(fakeApp.Password, single.Password);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.LastDateUsed, single.LastDateUsed);
            Assert.AreEqual(fakeApp.AuthenticationId, single.AuthenticationId);
        }

        [TestMethod]
        public void GetSingleHistoryIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeletePasswordHistories()
        {
            var currentCnt = testCtx.PasswordHistories.Count();

            var entity = testCtx.PasswordHistories.First();
            repo.Delete(entity.HistoryId);
            repo.Save();

            Assert.IsTrue(testCtx.PasswordHistories.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteHistoryIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 6898;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
