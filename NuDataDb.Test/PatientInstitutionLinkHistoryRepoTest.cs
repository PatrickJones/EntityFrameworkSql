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
    public class PatientInstitutionLinkHistoryRepoTest : BaseUnitTest<PatientInstitutionLinkHistory>
    {
        protected PatientLinkLogsRepo repo;

        protected override void SetContextData()
        {
            repo = new PatientLinkLogsRepo(testCtx);

            var b = new Faker<PatientInstitutionLinkHistory>()
                .RuleFor(r => r.InstitutionId, f => f.Random.Uuid())
                .RuleFor(r => r.PatientId, f => f.Random.Uuid())
                .RuleFor(r => r.Date, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)))
                .RuleFor(r => r.LinkStatus, f => f.Random.Int());

            var bs = b.Generate(3).OrderBy(o => o.Date).ToList();
            FakeCollection.AddRange(bs);

            testCtx.PatientLinkLogs.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleDataLinkLog()
        {
            var fakeApp = FakeCollection.First();
            //var single = repo.GetSingle(fakeApp.PatientId);
            Assert.ThrowsException<NotSupportedException>(() => repo.GetSingle(fakeApp.PatientId));

            //Assert.AreEqual(fakeApp.InstitutionId, single.InstitutionId);
            //Assert.AreEqual(fakeApp.PatientId, single.PatientId);
            //Assert.AreEqual(fakeApp.Date, single.Date);
            //Assert.AreEqual(fakeApp.LinkStatus, single.LinkStatus);
        }

        //[TestMethod]
        //public void GetSingleLinkIdNotExist()
        //{
        //    var fakeId = 333;
        //    var single = repo.GetSingle(fakeId);

        //    Assert.IsNull(single);
        //}


        [TestMethod]
        public void DeleteDataLinkLog()
        {
            var currentCnt = testCtx.PatientLinkLogs.Count();

            var entity = testCtx.PatientLinkLogs.First();

            Assert.ThrowsException<NotSupportedException>(() => repo.Delete(entity.PatientId));
            //repo.Delete(entity.PatientId);
            //repo.Save();

            //Assert.IsTrue(testCtx.PatientLinkLogs.Count() == --currentCnt);
        }

        //[TestMethod]
        //public void DeleteLinkIdNotExist()
        //{
        //    var currentCnt = testCtx.AppSettings.Count();

        //    var fakeId = 6488;
        //    repo.Delete(fakeId);
        //    repo.Save();

        //    Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        //}
    }
}
