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
    public class InsuranceContactsnRepoTest : BaseUnitTest<InsuranceContacts>
    {
        protected InsuranceContactsRepo repo;

        protected override void SetContextData()
        {
            repo = new InsuranceContactsRepo(testCtx);

            var b = new Faker<InsuranceContacts>()
                .RuleFor(r => r.FullName, f => f.Lorem.Letter(50))
                .RuleFor(r => r.CompanyId, f => f.Random.Int())
                .RuleFor(r => r.LastUpdatedByUser, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.ContactId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.InsuranceContacts.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleInsuranceContacts()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.ContactId);

            Assert.AreEqual(fakeApp.ContactId, single.ContactId);
            Assert.AreEqual(fakeApp.FullName, single.FullName);
            Assert.AreEqual(fakeApp.CompanyId, single.CompanyId);
            Assert.AreEqual(fakeApp.LastUpdatedByUser, single.LastUpdatedByUser);
        }

        [TestMethod]
        public void GetSingleContactIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteInsuranceContacts()
        {
            var currentCnt = testCtx.InsuranceContacts.Count();

            var entity = testCtx.InsuranceContacts.First();
            repo.Delete(entity.ContactId);
            repo.Save();

            Assert.IsTrue(testCtx.InsuranceContacts.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteContactIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 684;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
