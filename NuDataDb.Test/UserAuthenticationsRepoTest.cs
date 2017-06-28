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
    public class UserAuthenticationsnRepoTest : BaseUnitTest<UserAuthentications>
    {
        protected UserAuthenticationsRepo repo;

        protected override void SetContextData()
        {
            repo = new UserAuthenticationsRepo(testCtx);

            var b = new Faker<UserAuthentications>()
                .RuleFor(r => r.ApplicationId, f => f.Random.Uuid())
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.Username, f => f.Lorem.Letter(250))
                .RuleFor(r => r.Password, f => f.Lorem.Letter(150))
                .RuleFor(r => r.PasswordFailureCount, f => f.Random.Int())
                .RuleFor(r => r.LastActivityDate, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)))
                .RuleFor(r => r.LastLockOutDate, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)))
                .RuleFor(r => r.IsApproved, f => f.Random.Bool())
                .RuleFor(r => r.IsLockedOut, f => f.Random.Bool())
                .RuleFor(r => r.IsTempPassword, f => f.Random.Bool())
                .RuleFor(r => r.IsloggedIn, f => f.Random.Bool())
                .RuleFor(r => r.LastUpdatedByUser, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.AuthenticationId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.UserAuthentications.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleUserAuthentications()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.AuthenticationId);

            Assert.AreEqual(fakeApp.AuthenticationId, single.AuthenticationId);
            Assert.AreEqual(fakeApp.ApplicationId, single.ApplicationId);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.Username, single.Username);
            Assert.AreEqual(fakeApp.Password, single.Password);
            Assert.AreEqual(fakeApp.PasswordFailureCount, single.PasswordFailureCount);
            Assert.AreEqual(fakeApp.LastActivityDate, single.LastActivityDate);
            Assert.AreEqual(fakeApp.LastLockOutDate, single.LastLockOutDate);
            Assert.AreEqual(fakeApp.IsApproved, single.IsApproved);
            Assert.AreEqual(fakeApp.IsLockedOut, single.IsLockedOut);
            Assert.AreEqual(fakeApp.IsTempPassword, single.IsTempPassword);
            Assert.AreEqual(fakeApp.IsloggedIn, single.IsloggedIn);
            Assert.AreEqual(fakeApp.LastUpdatedByUser, single.LastUpdatedByUser);
        }

        [TestMethod]
        public void GetSingleAuthenticationIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteUserAuthentications()
        {
            var currentCnt = testCtx.UserAuthentications.Count();

            var entity = testCtx.UserAuthentications.First();
            repo.Delete(entity.AuthenticationId);
            repo.Save();

            Assert.IsTrue(testCtx.UserAuthentications.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteAuthenticationIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 4329;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
