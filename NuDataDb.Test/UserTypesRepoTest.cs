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
    public class UserTypesnRepoTest : BaseUnitTest<UserTypes>
    {
        protected UserTypesRepo repo;

        protected override void SetContextData()
        {
            repo = new UserTypesRepo(testCtx);

            var b = new Faker<UserTypes>()
                .RuleFor(r => r.TypeName, f => f.Lorem.Letter(50));

            var bs = b.Generate(3).OrderBy(o => o.TypeId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.UserTypes.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleUserTypes()
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
        public void DeleteUserTypes()
        {
            var currentCnt = testCtx.UserTypes.Count();

            var entity = testCtx.UserTypes.First();
            repo.Delete(entity.TypeId);
            repo.Save();

            Assert.IsTrue(testCtx.UserTypes.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteTypeIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 6942;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
