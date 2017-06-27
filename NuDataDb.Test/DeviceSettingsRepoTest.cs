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
    public class DeviceSettingsnRepoTest : BaseUnitTest<DeviceSettings>
    {
        Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected DeviceSettingsRepo repo;

        protected override void SetContextData()
        {
            repo = new DeviceSettingsRepo(testCtx);

            var b = new Faker<DeviceSettings>()
                .RuleFor(r => r.SettingId, f => itrtr32++)
                .RuleFor(r => r.Name, f => f.Lorem.Letter(150))
                .RuleFor(r => r.Value, f => f.Lorem.Letter(150))
                .RuleFor(r => r.ReadingKeyId, f => f.Random.Uuid())
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.DateSet, f => new DateTime(f.Random.Long()));

            var bs = b.Generate(3).OrderBy(o => o.SettingId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.DeviceSettings.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleDeviceSettings()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.SettingId);

            Assert.AreEqual(fakeApp.SettingId, single.SettingId);
            Assert.AreEqual(fakeApp.Name, single.Name);
            Assert.AreEqual(fakeApp.Value, single.Value);
            Assert.AreEqual(fakeApp.ReadingKeyId, single.ReadingKeyId);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.DateSet, single.DateSet);
        }

        public void GetSingleSettingIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteDeviceSettings()
        {
            var currentCnt = testCtx.DeviceSettings.Count();

            var entity = testCtx.DeviceSettings.First();
            repo.Delete(entity.SettingId);
            repo.Save();

            Assert.IsTrue(testCtx.DeviceSettings.Count() == --currentCnt);
        }

        public void DeleteSettingIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
