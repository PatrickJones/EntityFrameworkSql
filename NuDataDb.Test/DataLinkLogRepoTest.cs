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
    public class DataLinkLognRepoTest : BaseUnitTest<DataLinkLog>
    {
        //Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected DataLinkLogRepo repo;

        protected override void SetContextData()
        {
            repo = new DataLinkLogRepo(testCtx);

            var b = new Faker<DataLinkLog>()
                .RuleFor(r => r.LinkId, f => itrtr32++)
                .RuleFor(r => r.InstitutionId, f => f.Random.Uuid())
                .RuleFor(r => r.PatientId, f => f.Random.Uuid())
                .RuleFor(r => r.Date, f => new DateTime(f.Random.Long()))
                .RuleFor(r => r.LinkingAction, f => f.Random.Bool());

            var bs = b.Generate(3).OrderBy(o => o.LinkId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.DataLinkLog.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleDataLinkLog()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.LinkId);

            Assert.AreEqual(fakeApp.LinkId, single.LinkId);
            Assert.AreEqual(fakeApp.InstitutionId, single.InstitutionId);
            Assert.AreEqual(fakeApp.PatientId, single.PatientId);
            Assert.AreEqual(fakeApp.Date, single.Date);
            Assert.AreEqual(fakeApp.LinkingAction, single.LinkingAction);
        }

        public void GetSingleLinkIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteDataLinkLog()
        {
            var currentCnt = testCtx.DataLinkLog.Count();

            var entity = testCtx.DataLinkLog.First();
            repo.Delete(entity.LinkId);
            repo.Save();

            Assert.IsTrue(testCtx.DataLinkLog.Count() == --currentCnt);
        }

        public void DeleteLinkIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
