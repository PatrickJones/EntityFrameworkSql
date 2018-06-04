using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuDataDb.EFMetersDb;
using NuDataDb.Repositories.MeterDbRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Test.MeterDbTest
{
    [TestClass]
    public class LogMessageTypesRepoTest : BaseUnitTest<MeterDevicesDbContext, LogMessageTypes>
    {
        protected LogMessageTypesRepo repo;

        protected override void SetContextData()
        {
            repo = new LogMessageTypesRepo(testCtx);

            var f = new Faker<LogMessageTypes>()
                .RuleFor(r => r.TypeName, v => v.PickRandomParam<string>("Informational", "Warning", "Error", "Critical"));

            var gen = f.Generate(3).OrderBy(o => o.Code).ToList();
            testCtx.LogMessageTypes.AddRange(gen);
            FakeCollection.AddRange(gen);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleLogMessageTypes()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.Code);

            Assert.AreEqual(fakeApp.Code, single.Code);
            Assert.AreEqual(fakeApp.TypeName, single.TypeName);
        }

        [TestMethod]
        public void GetSingleLogMessageTypesIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }

        [TestMethod]
        public void DeleteLogMessageTypes()
        {
            var currentCnt = testCtx.LogMessageTypes.Count();

            var entity = testCtx.LogMessageTypes.First();
            repo.Delete(entity.Code);
            repo.Save();

            Assert.IsTrue(testCtx.LogMessageTypes.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteLogMessageTypesIdNotExist()
        {
            var currentCnt = testCtx.LogMessageTypes.Count();

            var fakeId = 679;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.LogMessageTypes.Count() == currentCnt);
        }
    }
}
