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
    public class ApplicationRepoTest : BaseUnitTest<Applications>
    {
        protected ApplicationRepo repo;

        protected override void SetContextData()
        {
            repo = new ApplicationRepo(testCtx);

            var b = new Faker<Applications>()
                .RuleFor(r => r.ApplicationId, f => f.Random.Uuid())
                .RuleFor(r => r.Description, f => f.Lorem.Sentence(5))
                .RuleFor(r => r.LastUpdatedByUser, f => f.Random.Uuid())
                .RuleFor(r => r.ApplicationName, f => f.Lorem.Word())
                .RuleFor(r => r.BannerEnable, f => f.Random.Bool())
                .RuleFor(r => r.SupportEmail, f => f.Internet.ExampleEmail());

            var bs = b.Generate(3).OrderBy(o => o.ApplicationName).ThenBy(o => o.SupportEmail).ToList();
            FakeCollection.AddRange(bs);

            testCtx.Applications.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleApplication()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.ApplicationId);

            Assert.AreEqual(fakeApp.ApplicationId, single.ApplicationId);
            Assert.AreEqual(fakeApp.ApplicationName, single.ApplicationName);
        }

        [TestMethod]
        public void GetSingleApplicationIdNotExist()
        {
            var fakeId = Guid.NewGuid();
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }

        [TestMethod]
        public void DeleteApplication()
        {
            var currentCnt = testCtx.Applications.Count();

            var entity = testCtx.Applications.First();
            repo.Delete(entity.ApplicationId);
            repo.Save();

            Assert.IsTrue(testCtx.Applications.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteApplicationIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = Guid.NewGuid();
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }

    }
}
