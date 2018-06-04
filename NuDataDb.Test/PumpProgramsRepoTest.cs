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
    public class PumpProgramsnRepoTest : BaseUnitTest<NuMedicsGlobalContext,PumpPrograms>
    {
        protected PumpProgramsRepo repo;

        protected override void SetContextData()
        {
            repo = new PumpProgramsRepo(testCtx);

            var b = new Faker<PumpPrograms>()
                .RuleFor(r => r.CreationDate, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)))
                .RuleFor(r => r.ProgramName, f => f.Lorem.Letter(50))
                .RuleFor(r => r.ProgramKey, f => f.Random.Int())
                .RuleFor(r => r.Valid, f => f.Random.Bool())
                .RuleFor(r => r.NumOfSegments, f => f.Random.Int())
                .RuleFor(r => r.PumpKeyId, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.PumpProgramId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.PumpPrograms.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSinglePumpPrograms()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.PumpProgramId);

            Assert.AreEqual(fakeApp.PumpProgramId, single.PumpProgramId);
            Assert.AreEqual(fakeApp.CreationDate, single.CreationDate);
            Assert.AreEqual(fakeApp.ProgramName, single.ProgramName);
            Assert.AreEqual(fakeApp.ProgramKey, single.ProgramKey);
            Assert.AreEqual(fakeApp.Valid, single.Valid);
            Assert.AreEqual(fakeApp.NumOfSegments, single.NumOfSegments);
            Assert.AreEqual(fakeApp.PumpKeyId, single.PumpKeyId);
        }

        [TestMethod]
        public void GetSinglePumpProgramIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeletePumpPrograms()
        {
            var currentCnt = testCtx.PumpPrograms.Count();

            var entity = testCtx.PumpPrograms.First();
            repo.Delete(entity.PumpProgramId);
            repo.Save();

            Assert.IsTrue(testCtx.PumpPrograms.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeletePumpProgramIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 432;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
