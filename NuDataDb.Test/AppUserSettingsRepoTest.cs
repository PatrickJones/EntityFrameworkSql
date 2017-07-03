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
    public class AppUserSettingsnRepoTest : BaseUnitTest<AppUserSettings>
    {
        protected AppUserSettingsRepo repo;

        protected override void SetContextData()
        {
            repo = new AppUserSettingsRepo(testCtx);

            var b = new Faker<AppUserSettings>()
                .RuleFor(r => r.Name, f => f.Lorem.Paragraph())
                .RuleFor(r => r.Value, f => f.Lorem.Paragraph())
                .RuleFor(r => r.ApplicationId, f => f.Random.Uuid())
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.LastUpdatedByUser, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.AppUserSettingId).ToList();
            testCtx.AppUserSettings.AddRange(bs);
            FakeCollection.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleAppUserSettings()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.AppUserSettingId);

            Assert.AreEqual(fakeApp.AppUserSettingId, single.AppUserSettingId);
            Assert.AreEqual(fakeApp.Name, single.Name);
        }

        [TestMethod]
        public void GetSingleAppUserSettingIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteAppUserSettings()
        {
            var currentCnt = testCtx.AppUserSettings.Count();

            var entity = testCtx.AppUserSettings.First();
            repo.Delete(entity.AppUserSettingId);
            repo.Save();

            Assert.IsTrue(testCtx.AppUserSettings.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteAppUserSettingIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 679;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
