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
    public class BGTargetsnRepoTest : BaseUnitTest<NuMedicsGlobalContext,Bgtargets>
    {
        protected BGTargetsRepo repo;

        protected override void SetContextData()
        {
            repo = new BGTargetsRepo(testCtx);

            var b = new Faker<Bgtargets>()
                .RuleFor(r => r.TargetBg, f => f.Random.Int())
                .RuleFor(r => r.TargetBgcorrect, f => f.Random.Int())
                .RuleFor(r => r.Date, f => DateTime.Now);

            var bs = b.Generate(3).OrderBy(o => o.TargetId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.Bgtargets.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleBGTargets()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.TargetId);

            Assert.AreEqual(fakeApp.TargetId, single.TargetId);
            Assert.AreEqual(fakeApp.TargetBg, single.TargetBg);
        }

        [TestMethod]
        public void GetSingleTargetIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }

        [TestMethod]
        public void DeleteBGTargets()
        {
            var currentCnt = testCtx.Bgtargets.Count();

            var entity = testCtx.Bgtargets.First();
            repo.Delete(entity.TargetId);
            repo.Save();

            Assert.IsTrue(testCtx.Bgtargets.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteTargetIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = 1246;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
