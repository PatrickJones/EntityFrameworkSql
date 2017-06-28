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
    public class PumpsnRepoTest : BaseUnitTest<Pumps>
    {
        protected PumpsRepo repo;

        protected override void SetContextData()
        {
            repo = new PumpsRepo(testCtx);

            var b = new Faker<Pumps>()
                .RuleFor(r => r.PumpKeyId, f => f.Random.Uuid())
                .RuleFor(r => r.PumpName, f => f.Lorem.Letter(50))
                .RuleFor(r => r.PumpStartDate, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)))
                .RuleFor(r => r.ActiveProgramId, f => f.Random.Int())
                .RuleFor(r => r.Cannula, f => f.Random.Float())
                .RuleFor(r => r.ReplacementDate, f => new DateTime(f.Random.Long(
                    DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks)))
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.PumpKeyId, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.PumpKeyId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.Pumps.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSinglePumps()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.PumpKeyId);

            Assert.AreEqual(fakeApp.PumpKeyId, single.PumpKeyId);
            Assert.AreEqual(fakeApp.PumpName, single.PumpName);
            Assert.AreEqual(fakeApp.PumpStartDate, single.PumpStartDate);
            Assert.AreEqual(fakeApp.ActiveProgramId, single.ActiveProgramId);
            Assert.AreEqual(fakeApp.Cannula, single.Cannula);
            Assert.AreEqual(fakeApp.ReplacementDate, single.ReplacementDate);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.PumpKeyId, single.PumpKeyId);
        }

        [TestMethod]
        public void GetSinglePumpKeyIdNotExist()
        {
            var fakeId = Guid.NewGuid();
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeletePumps()
        {
            var currentCnt = testCtx.Pumps.Count();

            var entity = testCtx.Pumps.First();
            repo.Delete(entity.PumpKeyId);
            repo.Save();

            Assert.IsTrue(testCtx.Pumps.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeletePumpKeyIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = Guid.NewGuid();
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
