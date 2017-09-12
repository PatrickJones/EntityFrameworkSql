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
    public class DeviceDatanRepoTest : BaseUnitTest<NuMedicsGlobalContext,DeviceData>
    {
        protected DeviceDataRepo repo;

        protected override void SetContextData()
        {
            repo = new DeviceDataRepo(testCtx);

            var b = new Faker<DeviceData>()
                .RuleFor(r => r.DataSet, f => f.Lorem.Word())
                .RuleFor(r => r.LastUpdate, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)));

            var bs = b.Generate(3).OrderBy(o => o.DataSetId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.DeviceData.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleDeviceData()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.DataSetId);

            Assert.AreEqual(fakeApp.DataSetId, single.DataSetId);
            Assert.AreEqual(fakeApp.DataSet, single.DataSet);
            Assert.AreEqual(fakeApp.LastUpdate, single.LastUpdate);
        }

        [TestMethod]
        public void GetSingleDataSetIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteDeviceData()
        {
            var currentCnt = testCtx.DeviceData.Count();

            var entity = testCtx.DeviceData.First();
            repo.Delete(entity.DataSetId);
            repo.Save();

            Assert.IsTrue(testCtx.DeviceData.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteDataSetIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 276;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
