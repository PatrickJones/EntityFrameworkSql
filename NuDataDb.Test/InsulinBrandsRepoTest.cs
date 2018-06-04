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
    public class InsulinBrandsnRepoTest : BaseUnitTest<NuMedicsGlobalContext,InsulinBrands>
    {
        protected InsulinBrandsRepo repo;

        protected override void SetContextData()
        {
            repo = new InsulinBrandsRepo(testCtx);

            var b = new Faker<InsulinBrands>()
                .RuleFor(r => r.BrandName, f => f.Lorem.Letter(80))
                .RuleFor(r => r.InsulinType, f => f.Random.Int());

            var bs = b.Generate(3).OrderBy(o => o.InsulinBrandId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.InsulinBrands.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleInsulinBrands()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.InsulinBrandId);

            Assert.AreEqual(fakeApp.InsulinBrandId, single.InsulinBrandId);
            Assert.AreEqual(fakeApp.BrandName, single.BrandName);
            Assert.AreEqual(fakeApp.InsulinType, single.InsulinType);
        }

        [TestMethod]
        public void GetSingleInsulinBrandIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteInsulinBrands()
        {
            var currentCnt = testCtx.InsulinBrands.Count();

            var entity = testCtx.InsulinBrands.First();
            repo.Delete(entity.InsulinBrandId);
            repo.Save();

            Assert.IsTrue(testCtx.InsulinBrands.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteInsulinBrandIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 6524;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
