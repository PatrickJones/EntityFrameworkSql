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
    public class TherapyTypesnRepoTest : BaseUnitTest<TherapyTypes>
    {
        protected TherapyTypesRepo repo;

        protected override void SetContextData()
        {
            repo = new TherapyTypesRepo(testCtx);

            var b = new Faker<TherapyTypes>()
                .RuleFor(r => r.TypeName, f => f.Lorem.Letter(150));

            var bs = b.Generate(3).OrderBy(o => o.TypeId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.TherapyTypes.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleTherapyTypes()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.TypeId);

            Assert.AreEqual(fakeApp.TypeId, single.TypeId);
            Assert.AreEqual(fakeApp.TypeName, single.TypeName);
        }

        [TestMethod]
        public void GetSingleTypeIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteTherapyTypes()
        {
            var currentCnt = testCtx.TherapyTypes.Count();

            var entity = testCtx.TherapyTypes.First();
            repo.Delete(entity.TypeId);
            repo.Save();

            Assert.IsTrue(testCtx.TherapyTypes.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteTypeIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 927;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
