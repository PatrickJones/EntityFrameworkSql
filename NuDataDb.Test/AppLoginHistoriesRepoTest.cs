using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuDataDb.EF;
using NuDataDb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NuDataDb.Test
{
    [TestClass]
    public class AppLoginHistoriesnRepoTest : BaseUnitTest<AppLoginHistories>
    {
        int itrtr32 = 0;

        protected AppLoginHistoriesRepo repo;

        protected override void SetContextData()
        {
            itrtr32 = 1;
            repo = new AppLoginHistoriesRepo(testCtx);

            var b = new Faker<AppLoginHistories>()
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.LoginDate, f => DateTime.Now)
                .RuleFor(r => r.ApplicationId, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.HistoryId).ToList();
            foreach (var item in bs)
            {
                item.HistoryId = itrtr32;

                if (!FakeCollection.Any(a => a.HistoryId == item.HistoryId))
                {
                    FakeCollection.Add(item);
                    
                }

                if (!testCtx.AppLoginHistories.Any(a => a.HistoryId == item.HistoryId))
                {
                    testCtx.AppLoginHistories.Add(item);
                }

                itrtr32++;
            }
            
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleAppLoginHistories()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.HistoryId);

            Assert.AreEqual(fakeApp.HistoryId, single.HistoryId);
            Assert.AreEqual(fakeApp.LoginDate, single.LoginDate);
        }

        [TestMethod]
        public void GetSingleHistoryIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }

        [TestMethod]
        public void DeleteAppLoginHistories()
        {
            var currentCnt = testCtx.AppLoginHistories.Count();

            var entity = testCtx.AppLoginHistories.First();
            repo.Delete(entity.HistoryId);
            repo.Save();

            Assert.IsTrue(testCtx.AppLoginHistories.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteHistoryIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
