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
    public class InsuranceProvidersnRepoTest : BaseUnitTest<InsuranceProviders>
    {
        Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected InsuranceProvidersRepo repo;

        protected override void SetContextData()
        {
            repo = new InsuranceProvidersRepo(testCtx);

            var b = new Faker<InsuranceProviders>()
                .RuleFor(r => r.CompanyId, f => itrtr32++)
                .RuleFor(r => r.LastUpdatedByUser, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.CompanyId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.InsuranceProviders.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleInsuranceProviders()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.CompanyId);

            Assert.AreEqual(fakeApp.CompanyId, single.CompanyId);
            Assert.AreEqual(fakeApp.LastUpdatedByUser, single.LastUpdatedByUser);
        }

        public void GetSingleCompanyIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteInsuranceProviders()
        {
            var currentCnt = testCtx.InsuranceProviders.Count();

            var entity = testCtx.InsuranceProviders.First();
            repo.Delete(entity.CompanyId);
            repo.Save();

            Assert.IsTrue(testCtx.InsuranceProviders.Count() == --currentCnt);
        }

        public void DeleteCompanyIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
