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
    public class DeviceHostMessagesRepoTest : BaseUnitTest<MeterDevicesDbContext, DeviceHostMessages>
    {
        protected DeviceHostMessagesRepo repo;

        protected override void SetContextData()
        {
            repo = new DeviceHostMessagesRepo(testCtx);

            var f = new Faker<DeviceHostMessages>()
                .RuleFor(r => r.Message, v => v.Lorem.Sentence())
                .RuleFor(r => r.LastUpdated, v => v.Date.Past());

            var gen = f.Generate(3).OrderBy(o => o.MessageId).ToList();
            testCtx.DeviceHostMessages.AddRange(gen);
            FakeCollection.AddRange(gen);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetDeviceHostMessage()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.MessageId);

            Assert.AreEqual(fakeApp.MessageId, single.MessageId);
            Assert.AreEqual(fakeApp.Message, single.Message);
        }

        [TestMethod]
        public void GetSingleDeviceHostMessageIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteDeviceHostMessage()
        {
            var currentCnt = testCtx.DeviceHostMessages.Count();

            var entity = testCtx.DeviceHostMessages.First();
            repo.Delete(entity.MessageId);
            repo.Save();

            Assert.IsTrue(testCtx.DeviceHostMessages.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteDeviceHostMessageIdNotExist()
        {
            var currentCnt = testCtx.DeviceHostMessages.Count();

            var fakeId = 679;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.DeviceHostMessages.Count() == currentCnt);
        }

    }
}
