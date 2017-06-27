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
    public class DiabetesControlTypesnRepoTest : BaseUnitTest<DiabetesControlTypes>
    {
        //Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected DiabetesControlTypesRepo repo;

        protected override void SetContextData()
        {
            repo = new DiabetesControlTypesRepo(testCtx);

            var b = new Faker<DiabetesControlTypes>()
                .RuleFor(r => r.TypeId, f => itrtr32++)
                .RuleFor(r => r.ControlName, f => f.Lorem.Letter(150))
                .RuleFor(r => r.IsEnabled, f => f.Random.Bool())
                .RuleFor(r => r.DmdataId, f => f.Random.Int())
                .RuleFor(r => r.CareSettingsId, f => f.Random.Int())
                .RuleFor(r => r.LastUpdatedByUser, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.TypeId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.DiabetesControlTypes.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleDiabetesControlTypes()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.TypeId);

            Assert.AreEqual(fakeApp.TypeId, single.TypeId);
            Assert.AreEqual(fakeApp.ControlName, single.ControlName);
            Assert.AreEqual(fakeApp.IsEnabled, single.IsEnabled);
            Assert.AreEqual(fakeApp.DmdataId, single.DmdataId);
            Assert.AreEqual(fakeApp.CareSettingsId, single.CareSettingsId);
            Assert.AreEqual(fakeApp.LastUpdatedByUser, single.LastUpdatedByUser);
        }

        public void GetSingleTypeIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteDiabetesControlTypes()
        {
            var currentCnt = testCtx.DiabetesControlTypes.Count();

            var entity = testCtx.DiabetesControlTypes.First();
            repo.Delete(entity.TypeId);
            repo.Save();

            Assert.IsTrue(testCtx.DiabetesControlTypes.Count() == --currentCnt);
        }

        public void DeleteTypeIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
