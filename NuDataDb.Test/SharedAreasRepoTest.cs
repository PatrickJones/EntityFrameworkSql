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
    public class SharedAreasnRepoTest : BaseUnitTest<SharedAreas>
    {
        Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected SharedAreasRepo repo;

        protected override void SetContextData()
        {
            repo = new SharedAreasRepo(testCtx);

            var b = new Faker<SharedAreas>()
                .RuleFor(r => r.ShareId, f => itrtr32++)
                .RuleFor(r => r.SharedCategoryId, f => f.Random.Int())
                .RuleFor(r => r.RequestId, f => f.Random.Int());

            var bs = b.Generate(3).OrderBy(o => o.ShareId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.SharedAreas.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleSharedAreas()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.ShareId);

            Assert.AreEqual(fakeApp.ShareId, single.ShareId);
            Assert.AreEqual(fakeApp.SharedCategoryId, single.SharedCategoryId);
            Assert.AreEqual(fakeApp.RequestId, single.RequestId);
        }

        public void GetSingleShareIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteSharedAreas()
        {
            var currentCnt = testCtx.SharedAreas.Count();

            var entity = testCtx.SharedAreas.First();
            repo.Delete(entity.ShareId);
            repo.Save();

            Assert.IsTrue(testCtx.SharedAreas.Count() == --currentCnt);
        }

        public void DeleteShareIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
