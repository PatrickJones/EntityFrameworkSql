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
    public class PatientDevicesnRepoTest : BaseUnitTest<NuMedicsGlobalContext,PatientDevices>
    {
        protected PatientDevicesRepo repo;

        protected override void SetContextData()
        {
            repo = new PatientDevicesRepo(testCtx);

            var b = new Faker<PatientDevices>()
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.MeterIndex, f => f.Random.Int())
                .RuleFor(r => r.Manufacturer, f => f.Lorem.Letter(150));

            var bs = b.Generate(3).OrderBy(o => o.DeviceId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.PatientDevices.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSinglePatientDevices()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.DeviceId);

            Assert.AreEqual(fakeApp.DeviceId, single.DeviceId);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.MeterIndex, single.MeterIndex);
            Assert.AreEqual(fakeApp.Manufacturer, single.Manufacturer);
        }

        [TestMethod]
        public void GetSingleDeviceIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeletePatientDevices()
        {
            var currentCnt = testCtx.PatientDevices.Count();

            var entity = testCtx.PatientDevices.First();
            repo.Delete(entity.DeviceId);
            repo.Save();

            Assert.IsTrue(testCtx.PatientDevices.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteDeviceIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 259;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
