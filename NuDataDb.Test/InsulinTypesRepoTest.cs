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
    public class InsulinTypesnRepoTest : BaseUnitTest<InsulinTypes>
    {
        Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected InsulinTypesRepo repo;

        protected override void SetContextData()
        {
            repo = new InsulinTypesRepo(testCtx);

            var b = new Faker<InsulinTypes>()
                .RuleFor(r => r.InsulinTypeId, f => itrtr32++)
                .RuleFor(r => r.Type, f => f.Lorem.Letter(50));

            var bs = b.Generate(3).OrderBy(o => o.InsulinTypeId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.InsulinTypes.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleInsulinTypes()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.InsulinTypeId);

            Assert.AreEqual(fakeApp.InsulinTypeId, single.InsulinTypeId);
            Assert.AreEqual(fakeApp.Type, single.Type);
        }

        public void GetSingleInsulinTypeIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteInsulinTypes()
        {
            var currentCnt = testCtx.InsulinTypes.Count();

            var entity = testCtx.InsulinTypes.First();
            repo.Delete(entity.InsulinTypeId);
            repo.Save();

            Assert.IsTrue(testCtx.InsulinTypes.Count() == --currentCnt);
        }

        public void DeleteInsulinTypeIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
