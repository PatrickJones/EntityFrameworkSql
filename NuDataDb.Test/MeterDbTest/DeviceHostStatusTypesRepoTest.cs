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
    public class DeviceHostStatusTypesRepoTest : BaseUnitTest<MeterDevicesDbContext, DeviceHostStatusTypes>
    {
        protected DeviceHostStatusTypesRepo repo;

        protected override void SetContextData()
        {
            repo = new DeviceHostStatusTypesRepo(testCtx);

            var f = new Faker<DeviceHostStatusTypes>()
                .RuleFor(r => r.Status, v => v.PickRandomParam<string>("Started", "Stopped", "Indeterminate"));

            var gen = f.Generate(3).OrderBy(o => o.StatusId).ToList();
            testCtx.DeviceHostStatusTypes.AddRange(gen);
            FakeCollection.AddRange(gen);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleDeviceHostStatusTypes()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.StatusId);

            Assert.AreEqual(fakeApp.StatusId, single.StatusId);
            Assert.AreEqual(fakeApp.Status, single.Status);
        }

        [TestMethod]
        public void GetSingleDeviceHostStatusTypesIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteDeviceHostStatusTypes()
        {
            var currentCnt = testCtx.DeviceHostStatusTypes.Count();

            var entity = testCtx.DeviceHostStatusTypes.First();
            repo.Delete(entity.StatusId);
            repo.Save();

            Assert.IsTrue(testCtx.DeviceHostStatusTypes.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteDeviceHostStatusTypesIdNotExist()
        {
            var currentCnt = testCtx.DeviceHostStatusTypes.Count();

            var fakeId = 679;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.DeviceHostStatusTypes.Count() == currentCnt);
        }
    }
}
