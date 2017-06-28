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
    public class InsulinMethodsnRepoTest : BaseUnitTest<InsulinMethods>
    {
        protected InsulinMethodsRepo repo;

        protected override void SetContextData()
        {
            repo = new InsulinMethodsRepo(testCtx);

            var b = new Faker<InsulinMethods>()
                .RuleFor(r => r.Method, f => f.Lorem.Letter(150));

            var bs = b.Generate(3).OrderBy(o => o.InsulinMethodId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.InsulinMethods.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleInsulinMethods()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.InsulinMethodId);

            Assert.AreEqual(fakeApp.InsulinMethodId, single.InsulinMethodId);
            Assert.AreEqual(fakeApp.Method, single.Method);
        }

        [TestMethod]
        public void GetSingleInsulinMethodIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteInsulinMethods()
        {
            var currentCnt = testCtx.InsulinMethods.Count();

            var entity = testCtx.InsulinMethods.First();
            repo.Delete(entity.InsulinMethodId);
            repo.Save();

            Assert.IsTrue(testCtx.InsulinMethods.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteInsulinMethodIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 628;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
