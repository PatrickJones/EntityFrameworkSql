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
    public class ApplicationsnRepoTest : BaseUnitTest<NuMedicsGlobalContext,Applications>
    {
        protected ApplicationsRepo repo;

        protected override void SetContextData()
        {
            repo = new ApplicationsRepo(testCtx);

            var b = new Faker<Applications>()
                .RuleFor(r => r.ApplicationId, f => f.Random.Uuid())
                .RuleFor(r => r.Description, f => f.Lorem.Sentence(5))
                .RuleFor(r => r.LastUpdatedbyUser, f => f.Random.Uuid())
                .RuleFor(r => r.ApplicationName, f => f.Lorem.Word())
                .RuleFor(r => r.BannerEnable, f => f.Random.Bool())
                .RuleFor(r => r.SupportEmail, f => f.Internet.ExampleEmail());

            var bs = b.Generate(3).OrderBy(o => o.ApplicationId).ThenBy(o => o.SupportEmail).ToList();
            FakeCollection.AddRange(bs);

            testCtx.Applications.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleApplications()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.ApplicationId);

            Assert.AreEqual(fakeApp.ApplicationId, single.ApplicationId);
            Assert.AreEqual(fakeApp.ApplicationName, single.ApplicationName);
            Assert.AreEqual(fakeApp.ApplicationOwner, single.ApplicationOwner);
        }

        [TestMethod]
        public void GetSingleApplicationIdNotExist()
        {
            var fakeId = new Guid();
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }

        [TestMethod]
        public void DeleteApplications()
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
