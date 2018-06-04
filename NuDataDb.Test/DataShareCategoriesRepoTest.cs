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
    public class DataShareCategoriesnRepoTest : BaseUnitTest<NuMedicsGlobalContext,DataShareCategories>
    {
        protected DataShareCategoriesRepo repo;

        protected override void SetContextData()
        {
            repo = new DataShareCategoriesRepo(testCtx);

            var b = new Faker<DataShareCategories>()
                .RuleFor(r => r.CategoryName, f => f.Lorem.Letter(150));

            var bs = b.Generate(3).OrderBy(o => o.CategoryId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.DataShareCategories.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleDataShareCategories()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.CategoryId);

            Assert.AreEqual(fakeApp.CategoryId, single.CategoryId);
            Assert.AreEqual(fakeApp.CategoryName, single.CategoryName);
        }

        [TestMethod]
        public void GetSingleCategoryIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }

        [TestMethod]
        public void DeleteDataShareCategories()
        {
            var currentCnt = testCtx.DataShareCategories.Count();

            var entity = testCtx.DataShareCategories.First();
            repo.Delete(entity.CategoryId);
            repo.Save();

            Assert.IsTrue(testCtx.DataShareCategories.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteCategoryIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 4684;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
