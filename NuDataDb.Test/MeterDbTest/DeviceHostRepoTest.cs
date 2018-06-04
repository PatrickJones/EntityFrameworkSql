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
    public class DeviceHostRepoTest : BaseUnitTest<MeterDevicesDbContext, DeviceHost>
    {
        protected DeviceHostRepo repo;

        protected override void SetContextData()
        {
            repo = new DeviceHostRepo(testCtx);

            var f = new Faker<DeviceHost>()
                .RuleFor(r => r.DeviceHostId, v => v.Random.Uuid())
                .RuleFor(r => r.ComputerName, v => v.Company.CompanyName())
                .RuleFor(r => r.InstallDate, v => v.Date.Past())
                .RuleFor(r => r.IpAddress, v => v.Internet.Ip())
                .RuleFor(r => r.IsInstitution, v => v.Random.Bool())
                .RuleFor(r => r.Macaddress, v => v.Internet.Mac())
                .RuleFor(r => r.SiteId, v => v.Random.Int(1000, 10000))
                .RuleFor(r => r.Status, v => v.Random.Int(1, 3));

            var gen = f.Generate(3).OrderBy(o => o.DeviceHostId).ToList();
            testCtx.DeviceHost.AddRange(gen);
            FakeCollection.AddRange(gen);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleDeviceHost()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.DeviceHostId);

            Assert.AreEqual(fakeApp.DeviceHostId, single.DeviceHostId);
            Assert.AreEqual(fakeApp.ComputerName, single.ComputerName);
            Assert.AreEqual(fakeApp.IpAddress, single.IpAddress);
            Assert.AreEqual(fakeApp.SiteId, single.SiteId);
        }

        [TestMethod]
        public void GetSingleDeviceHostIdNotExist()
        {
            var fakeId = Guid.NewGuid();
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteDeviceHost()
        {
            var currentCnt = testCtx.DeviceHost.Count();

            var entity = testCtx.DeviceHost.First();
            repo.Delete(entity.DeviceHostId);
            repo.Save();

            Assert.IsTrue(testCtx.DeviceHost.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteDeviceHostIdNotExist()
        {
            var currentCnt = testCtx.DeviceHost.Count();

            var fakeId = Guid.NewGuid();
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.DeviceHost.Count() == currentCnt);
        }

    }
}
