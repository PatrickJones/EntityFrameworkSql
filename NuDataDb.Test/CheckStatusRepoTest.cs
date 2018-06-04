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
    public class CheckStatusnRepoTest : BaseUnitTest<NuMedicsGlobalContext,CheckStatus>
    {
        protected CheckStatusRepo repo;

        protected override void SetContextData()
        {
            repo = new CheckStatusRepo(testCtx);

            var b = new Faker<CheckStatus>()
                .RuleFor(r => r.Status, f => f.Lorem.Letter(50));

            var bs = b.Generate(3).OrderBy(o => o.StatusId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.CheckStatus.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleCheckStatus()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.StatusId);

            Assert.AreEqual(fakeApp.StatusId, single.StatusId);
            Assert.AreEqual(fakeApp.Status, single.Status);
        }

        [TestMethod]
        public void GetSingleStatusIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }

        [TestMethod]
        public void DeleteCheckStatus()
        {
            var currentCnt = testCtx.CheckStatus.Count();

            var entity = testCtx.CheckStatus.First();
            repo.Delete(entity.StatusId);
            repo.Save();

            Assert.IsTrue(testCtx.CheckStatus.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteStatusIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 87946;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
