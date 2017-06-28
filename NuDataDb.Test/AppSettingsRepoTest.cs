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
    public class AppSettingsnRepoTest : BaseUnitTest<AppSettings>
    {
        protected AppSettingsRepo repo;

        protected override void SetContextData()
        {
            repo = new AppSettingsRepo(testCtx);

            var b = new Faker<AppSettings>()
                .RuleFor(r => r.Name, f => f.Lorem.Word())
                .RuleFor(r => r.Value, f => f.Lorem.Word())
                .RuleFor(r => r.Description, f => f.Lorem.Paragraph())
                .RuleFor(r => r.ApplicationId, f => f.Random.Uuid())
                .RuleFor(r => r.LastUpdatedByUser, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.AppSettingId).ThenBy(o => o.Name).ToList();
            testCtx.AppSettings.AddRange(bs);
            FakeCollection.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleAppSettings()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.AppSettingId);

            Assert.AreEqual(fakeApp.AppSettingId, single.AppSettingId);
            Assert.AreEqual(fakeApp.Name, single.Name);
        }

        [TestMethod]
        public void GetSingleAppSettingIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteAppSettings()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var entity = testCtx.AppSettings.First();
            repo.Delete(entity.AppSettingId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteAppSettingIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 56;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
