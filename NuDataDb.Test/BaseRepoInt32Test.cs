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
    // Only testing the GET and DELETE operations that take a integer key overload
    // Full tests are in the 'BaseRepoGuidTest' class
    [TestClass]
    public class BaseRepoInt32Test : BaseUnitTest<AppSettings>
    {
        protected AppSettingsRepo repo;

        public BaseRepoInt32Test() : base("IntTest")
        {
        }

        protected override void SetContextData()
        {
            repo = new AppSettingsRepo(testCtx);

            var b = new Faker<AppSettings>()
                //.RuleFor(r => r.AppSettingId, f => f.UniqueIndex)
                .RuleFor(r => r.Description, f => f.Lorem.Sentence(5))
                .RuleFor(r => r.LastUpdatedbyUser, f => f.Random.Uuid())
                .RuleFor(r => r.Name, f => f.Lorem.Word())
                .RuleFor(r => r.Value, f => f.Lorem.Word());

            var bs = b.Generate(3).OrderBy(o => o.Name).ThenBy(o => o.Value).ToList();
            FakeCollection.AddRange(bs);

            testCtx.AppSettings.AddRange(bs);
            int added = testCtx.SaveChanges();
        }


        [TestMethod]
        public void GetSingleIntType()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.AppSettingId);

            Assert.AreEqual(fakeApp.AppSettingId, single.AppSettingId);
            Assert.AreEqual(fakeApp.Name, single.Name);
        }

        [TestMethod]
        public void GetSingleIntTypeIdNotExist()
        {
            int fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }

        [TestMethod]
        public void DeleteIntType()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var entity = testCtx.AppSettings.First();
            repo.Delete(entity.AppSettingId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteIntTypeIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            int fakeId = 333;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }

    }
}
