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
    public class UsersnRepoTest : BaseUnitTest<Users>
    {
        Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected UsersRepo repo;

        protected override void SetContextData()
        {
            repo = new UsersRepo(testCtx);

            var b = new Faker<Users>()
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.UserType, f => f.Random.Int())
                .RuleFor(r => r.CreationDate, f => new DateTime(f.Random.Long()));

            var bs = b.Generate(3).OrderBy(o => o.UserId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.Users.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleUsers()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.UserId);

            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.UserType, single.UserType);
            Assert.AreEqual(fakeApp.CreationDate, single.CreationDate);
        }

        public void GetSingleUserIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteUsers()
        {
            var currentCnt = testCtx.Users.Count();

            var entity = testCtx.Users.First();
            repo.Delete(entity.UserId);
            repo.Save();

            Assert.IsTrue(testCtx.Users.Count() == --currentCnt);
        }

        public void DeleteUserIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = Guid.NewGuid();
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
