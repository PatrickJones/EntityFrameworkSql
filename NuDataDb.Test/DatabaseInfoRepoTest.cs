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
    public class DatabaseInfonRepoTest : BaseUnitTest<DatabaseInfo>
    {
        protected DatabaseInfoRepo repo;

        protected override void SetContextData()
        {
            repo = new DatabaseInfoRepo(testCtx);

            var b = new Faker<DatabaseInfo>()
                .RuleFor(r => r.SiteId, f => f.Random.Int());

            var bs = b.Generate(3).OrderBy(o => o.Id).ToList();
            FakeCollection.AddRange(bs);

            testCtx.DatabaseInfo.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleDatabaseInfo()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.Id);

            Assert.AreEqual(fakeApp.Id, single.Id);
            Assert.AreEqual(fakeApp.SiteId, single.SiteId);
        }

        public void GetSingleIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteDatabaseInfo()
        {
            var currentCnt = testCtx.DatabaseInfo.Count();

            var entity = testCtx.DatabaseInfo.First();
            repo.Delete(entity.Id);
            repo.Save();

            Assert.IsTrue(testCtx.DatabaseInfo.Count() == --currentCnt);
        }

        public void DeleteIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 34612;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
