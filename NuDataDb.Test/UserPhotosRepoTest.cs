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
    public class UserPhotosnRepoTest : BaseUnitTest<UserPhotos>
    {
        //Int64 itrtr64 = 0;
        //int itrtr32 = 0;

        protected UserPhotosRepo repo;

        protected override void SetContextData()
        {
            repo = new UserPhotosRepo(testCtx);

            var b = new Faker<UserPhotos>()
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.Photo, f => f.Random.Bytes(5));

            var bs = b.Generate(3).OrderBy(o => o.UserId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.UserPhotos.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleUserPhotos()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.UserId);

            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.Photo, single.Photo);
        }

        public void GetSingleUserIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteUserPhotos()
        {
            var currentCnt = testCtx.UserPhotos.Count();

            var entity = testCtx.UserPhotos.First();
            repo.Delete(entity.UserId);
            repo.Save();

            Assert.IsTrue(testCtx.UserPhotos.Count() == --currentCnt);
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
