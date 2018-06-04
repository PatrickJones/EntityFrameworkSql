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
    public class PumpSettingsnRepoTest : BaseUnitTest<NuMedicsGlobalContext,PumpSettings>
    {
        protected PumpSettingsRepo repo;

        protected override void SetContextData()
        {
            repo = new PumpSettingsRepo(testCtx);

            var b = new Faker<PumpSettings>()
                .RuleFor(r => r.SettingName, f => f.Lorem.Letter(150))
                .RuleFor(r => r.SettingValue, f => f.Lorem.Letter(150))
                .RuleFor(r => r.PumpKeyId, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.SettingId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.PumpSettings.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSinglePumpSettings()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.SettingId);

            Assert.AreEqual(fakeApp.SettingId, single.SettingId);
            Assert.AreEqual(fakeApp.SettingName, single.SettingName);
            Assert.AreEqual(fakeApp.SettingValue, single.SettingValue);
            Assert.AreEqual(fakeApp.PumpKeyId, single.PumpKeyId);
        }

        [TestMethod]
        public void GetSingleSettingIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeletePumpSettings()
        {
            var currentCnt = testCtx.PumpSettings.Count();

            var entity = testCtx.PumpSettings.First();
            repo.Delete(entity.SettingId);
            repo.Save();

            Assert.IsTrue(testCtx.PumpSettings.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteSettingIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 246;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
