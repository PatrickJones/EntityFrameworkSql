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
        //Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected AppSettingsRepo repo;

        protected override void SetContextData()
        {
            repo = new AppSettingsRepo(testCtx);

            var b = new Faker<AppSettings>()
                .RuleFor(r => r.AppSettingId, f => itrtr32++)
                .RuleFor(r => r.Name, f => f.Lorem.Word())
                .RuleFor(r => r.Value, f => f.Lorem.Word())
                .RuleFor(r => r.Description, f => f.Lorem.Paragraph());

            var bs = b.Generate(3).OrderBy(o => o.AppSettingId).ThenBy(o => o.Name).ToList();
            FakeCollection.AddRange(bs);

            testCtx.AppSettings.AddRange(bs);
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

        public void DeleteAppSettingIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
