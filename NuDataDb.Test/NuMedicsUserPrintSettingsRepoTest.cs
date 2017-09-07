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
    public class NuMedicsUserPrintSettingsRepoTest : BaseUnitTest<NuMedicsUserPrintSettings>
    {
        protected NuMedicsUserPrintSettingsRepo repo;

        protected override void SetContextData()
        {
            repo = new NuMedicsUserPrintSettingsRepo(testCtx);

            var p = new Faker<NuMedicsUserPrintSettings>()
                .RuleFor(r => r.SettingsApplyToUser, v => v.Random.Uuid())
                .RuleFor(r => r.UserId, v => v.Random.Uuid())
                .RuleFor(r => r.JsonPrintSettings, v => v.Lorem.Paragraphs(6));

            var ps = p.Generate(3).OrderBy(o => o.PrintSettingId).ToList();
            FakeCollection.AddRange(ps);

            testCtx.NuMedicsUserPrintSettings.AddRange(ps);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSinglePrintSetting()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.PrintSettingId);

            Assert.AreEqual(fakeApp.PrintSettingId, single.PrintSettingId);
            Assert.AreEqual(fakeApp.SettingsApplyToUser, single.SettingsApplyToUser);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
        }

        [TestMethod]
        public void GetSinglePrintSettingsIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeletePrintSetting()
        {
            var currentCnt = testCtx.NuMedicsUserPrintSettings.Count();

            var entity = testCtx.NuMedicsUserPrintSettings.First();
            repo.Delete(entity.PrintSettingId);
            repo.Save();

            Assert.IsTrue(testCtx.NuMedicsUserPrintSettings.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeletePrintSettingIdNotExist()
        {
            var currentCnt = testCtx.NuMedicsUserPrintSettings.Count();

            var fakeId = 842;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.NuMedicsUserPrintSettings.Count() == currentCnt);
        }
    }
}
