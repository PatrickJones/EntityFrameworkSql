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
    public class DiabetesManagementDataRepoTest : BaseUnitTest<DiabetesManagementData>
    {
        //Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected DiabetesManagementDataRepo repo;

        protected override void SetContextData()
        {
            repo = new DiabetesManagementDataRepo(testCtx);

            var b = new Faker<DiabetesManagementData>()
                .RuleFor(r => r.DmdataId, f => itrtr32++)
                .RuleFor(r => r.LowBglevel, f => f.Random.Int())
                .RuleFor(r => r.HighBglevel, f => f.Random.Int())
                .RuleFor(r => r.PremealTarget, f => f.Random.Int())
                .RuleFor(r => r.PostmealTarget, f => f.Random.Int())
                .RuleFor(r => r.ModifiedDate, f => new DateTime(f.Random.Long()))
                .RuleFor(r => r.ModifiedUserId, f => f.Random.Uuid())
                .RuleFor(r => r.UserId, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.DmdataId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.DiabetesManagementData.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleDiabetesManagementData()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.DmdataId);

            Assert.AreEqual(fakeApp.DmdataId, single.DmdataId);
            Assert.AreEqual(fakeApp.LowBglevel, single.LowBglevel);
            Assert.AreEqual(fakeApp.HighBglevel, single.HighBglevel);
            Assert.AreEqual(fakeApp.PremealTarget, single.PremealTarget);
            Assert.AreEqual(fakeApp.PostmealTarget, single.PostmealTarget);
            Assert.AreEqual(fakeApp.ModifiedDate, single.ModifiedDate);
            Assert.AreEqual(fakeApp.ModifiedUserId, single.ModifiedUserId);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
        }

        public void GetSingleDMDataIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteDiabetesManagementData()
        {
            var currentCnt = testCtx.DiabetesManagementData.Count();

            var entity = testCtx.DiabetesManagementData.First();
            repo.Delete(entity.DmdataId);
            repo.Save();

            Assert.IsTrue(testCtx.DiabetesManagementData.Count() == --currentCnt);
        }

        public void DeleteDMDataIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
