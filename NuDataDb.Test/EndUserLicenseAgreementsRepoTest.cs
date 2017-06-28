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
    public class EndUserLicenseAgreementsnRepoTest : BaseUnitTest<EndUserLicenseAgreements>
    {
        protected EndUserLicenseAgreementsRepo repo;

        protected override void SetContextData()
        {
            repo = new EndUserLicenseAgreementsRepo(testCtx);

            var b = new Faker<EndUserLicenseAgreements>()
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.AgreementDate, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)))
                .RuleFor(r => r.ApplicationId, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.AgreementId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.EndUserLicenseAgreements.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleEndUserLicenseAgreements()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.AgreementId);

            Assert.AreEqual(fakeApp.AgreementId, single.AgreementId);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.AgreementDate, single.AgreementDate);
            Assert.AreEqual(fakeApp.ApplicationId, single.ApplicationId);
        }

        [TestMethod]
        public void GetSingleAgreementIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteEndUserLicenseAgreements()
        {
            var currentCnt = testCtx.EndUserLicenseAgreements.Count();

            var entity = testCtx.EndUserLicenseAgreements.First();
            repo.Delete(entity.AgreementId);
            repo.Save();

            Assert.IsTrue(testCtx.EndUserLicenseAgreements.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteAgreementIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 350;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
