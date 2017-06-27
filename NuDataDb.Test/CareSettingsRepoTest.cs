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
    public class CareSettingsnRepoTest : BaseUnitTest<CareSettings>
    {
        //Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected CareSettingsRepo repo;

        protected override void SetContextData()
        {
            repo = new CareSettingsRepo(testCtx);

            var b = new Faker<CareSettings>()
                .RuleFor(r => r.CareSettingsId, f => itrtr32++)
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.HyperglycemicLevel, f => f.Random.Int())
                .RuleFor(r => r.HypoglycemicLevel, f => f.Random.Int())
                .RuleFor(r => r.InsulinMethod, f => f.Random.Int())
                .RuleFor(r => r.DiabetesManagementType, f => f.Random.Int())
                .RuleFor(r => r.InsulinBrand, f => f.Random.Int())
                .RuleFor(r => r.DateModified, f => new DateTime(f.Random.Long()))
                .RuleFor(r => r.LastUpdatedByUser, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.CareSettingsId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.CareSettings.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleCareSettings()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.CareSettingsId);

            Assert.AreEqual(fakeApp.CareSettingsId, single.CareSettingsId);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
        }

        public void GetSingleCareSettingsIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteCareSettings()
        {
            var currentCnt = testCtx.CareSettings.Count();

            var entity = testCtx.CareSettings.First();
            repo.Delete(entity.CareSettingsId);
            repo.Save();

            Assert.IsTrue(testCtx.CareSettings.Count() == --currentCnt);
        }

        public void DeleteCareSettingsIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
