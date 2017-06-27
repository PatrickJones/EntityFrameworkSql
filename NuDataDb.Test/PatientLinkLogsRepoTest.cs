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
    public class PatientLinkLogsnRepoTest : BaseUnitTest<PatientLinkLogs>
    {
        Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected PatientLinkLogsRepo repo;

        protected override void SetContextData()
        {
            repo = new PatientLinkLogsRepo(testCtx);

            var b = new Faker<PatientLinkLogs>()
                .RuleFor(r => r.LinkId, f => itrtr32++)
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.InstitutionId, f => f.Random.Uuid())
                .RuleFor(r => r.LinkCreationDate, f => new DateTime(f.Random.Long()))
                .RuleFor(r => r.LinkSeverDate, f => new DateTime(f.Random.Long()))
                .RuleFor(r => r.HasFreeDownload, f => f.Random.Bool());

            var bs = b.Generate(3).OrderBy(o => o.LinkId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.PatientLinkLogs.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSinglePatientLinkLogs()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.LinkId);

            Assert.AreEqual(fakeApp.LinkId, single.LinkId);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.InstitutionId, single.InstitutionId);
            Assert.AreEqual(fakeApp.LinkCreationDate, single.LinkCreationDate);
            Assert.AreEqual(fakeApp.LinkSeverDate, single.LinkSeverDate);
            Assert.AreEqual(fakeApp.HasFreeDownload, single.HasFreeDownload);
        }

        public void GetSingleLinkIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeletePatientLinkLogs()
        {
            var currentCnt = testCtx.PatientLinkLogs.Count();

            var entity = testCtx.PatientLinkLogs.First();
            repo.Delete(entity.LinkId);
            repo.Save();

            Assert.IsTrue(testCtx.PatientLinkLogs.Count() == --currentCnt);
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
