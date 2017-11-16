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
    public class PumpProgramTypesRepoTest : BaseUnitTest<NuMedicsGlobalContext, PumpProgramTypes>
    {
        protected PumpProgramTypesRepo repo;

        protected override void SetContextData()
        {
            repo = new PumpProgramTypesRepo(testCtx);

            var b = new Faker<PumpProgramTypes>()
                .RuleFor(r => r.Name, f => f.Lorem.Letter(50));

            var bs = b.Generate(3).ToList();
            FakeCollection.AddRange(bs);

            testCtx.PumpProgramTypes.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSinglePumpProgramType()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.TypeId);

            Assert.AreEqual(fakeApp.TypeId, single.TypeId);
            Assert.AreEqual(fakeApp.Name, single.Name);

        }

        [TestMethod]
        public void GetSingleIdNotExist()
        {
            var fakeId = 888;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }

        [TestMethod]
        public void DeletePumpProgramType()
        {
            var currentCnt = testCtx.PumpProgramTypes.Count();

            var entity = testCtx.PumpProgramTypes.First();
            repo.Delete(entity.TypeId);
            repo.Save();

            Assert.IsTrue(testCtx.PumpProgramTypes.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 888;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }


    }
}
