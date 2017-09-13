using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuDataDb.EFMetersDb;
using NuDataDb.Repositories.MeterDbRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Test.MeterDbTest
{
    [TestClass]
    public class DeviceHostLogRepoTest : BaseUnitTest<MeterDevicesDbContext, DeviceHostLog>
    {
        protected DeviceHostLogRepo repo;

        protected override void SetContextData()
        {
            repo = new DeviceHostLogRepo(testCtx);

            var f = new Faker<DeviceHostLog>()
                .RuleFor(r => r.DeviceIdInvoked, v => v.Random.Int(1, 76))
                .RuleFor(r => r.LogDate, v => v.Date.Past())
                .RuleFor(r => r.LogMessageCode, v => v.Random.Int(1, 100))
                .RuleFor(r => r.LogMessageType, v => v.Random.Int(1, 4))
                .RuleFor(r => r.Message, v => v.Lorem.Sentence())
                .RuleFor(r => r.UserId, v => v.Random.Uuid());

            var gen = f.Generate(3).OrderBy(o => o.LogId).ToList();
            testCtx.DeviceHostLog.AddRange(gen);
            FakeCollection.AddRange(gen);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleDeviceHostLog()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.LogId);

            Assert.AreEqual(fakeApp.LogId, single.LogId);
            Assert.AreEqual(fakeApp.LogMessageCode, single.LogMessageCode);
            Assert.AreEqual(fakeApp.LogMessageType, single.LogMessageType);
            Assert.AreEqual(fakeApp.Message, single.Message);
        }

        [TestMethod]
        public void GetSingleDeviceHostLogIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteDeviceHostLog()
        {
            var currentCnt = testCtx.DeviceHostLog.Count();

            var entity = testCtx.DeviceHostLog.First();
            repo.Delete(entity.LogId);
            repo.Save();

            Assert.IsTrue(testCtx.DeviceHostLog.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteDeviceHostLogIdNotExist()
        {
            var currentCnt = testCtx.DeviceHostLog.Count();

            var fakeId = 679;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.DeviceHostLog.Count() == currentCnt);
        }
    }
}
