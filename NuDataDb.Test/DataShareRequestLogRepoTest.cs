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
    public class DataShareRequestLognRepoTest : BaseUnitTest<DataShareRequestLog>
    {
        //Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected DataShareRequestLogRepo repo;

        protected override void SetContextData()
        {
            repo = new DataShareRequestLogRepo(testCtx);

            var b = new Faker<DataShareRequestLog>()
                .RuleFor(r => r.RequestId, f => itrtr32++)
                .RuleFor(r => r.RequestDate, f => new DateTime(f.Random.Long()))
                .RuleFor(r => r.LastUpdate, f => new DateTime(f.Random.Long()))
                .RuleFor(r => r.ApplicationId, f => f.Random.Uuid())
                .RuleFor(r => r.PatientId, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.RequestId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.DataShareRequestLog.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleDataShareRequestLog()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.RequestId);

            Assert.AreEqual(fakeApp.RequestId, single.RequestId);
            Assert.AreEqual(fakeApp.RequestDate, single.RequestDate);
            Assert.AreEqual(fakeApp.LastUpdate, single.LastUpdate);
            Assert.AreEqual(fakeApp.ApplicationId, single.ApplicationId);
            Assert.AreEqual(fakeApp.PatientId, single.PatientId);
        }

        public void GetSingleRequestIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteDataShareRequestLog()
        {
            var currentCnt = testCtx.DataShareRequestLog.Count();

            var entity = testCtx.DataShareRequestLog.First();
            repo.Delete(entity.RequestId);
            repo.Save();

            Assert.IsTrue(testCtx.DataShareRequestLog.Count() == --currentCnt);
        }

        public void DeleteRequestIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
