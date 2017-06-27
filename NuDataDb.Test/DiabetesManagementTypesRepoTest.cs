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
    public class DiabetesManagementTypesnRepoTest : BaseUnitTest<DiabetesManagementTypes>
    {
        //Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected DiabetesManagementTypesRepo repo;

        protected override void SetContextData()
        {
            repo = new DiabetesManagementTypesRepo(testCtx);

            var b = new Faker<DiabetesManagementTypes>()
                .RuleFor(r => r.TypeId, f => itrtr32++)
                .RuleFor(r => r.Name, f => f.Lorem.Letter(150));

            var bs = b.Generate(3).OrderBy(o => o.TypeId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.DiabetesManagementTypes.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleDiabetesManagementTypes()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.TypeId);

            Assert.AreEqual(fakeApp.TypeId, single.TypeId);
            Assert.AreEqual(fakeApp.Name, single.Name);
        }

        public void GetSingleTypeIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteDiabetesManagementTypes()
        {
            var currentCnt = testCtx.DiabetesManagementTypes.Count();

            var entity = testCtx.DiabetesManagementTypes.First();
            repo.Delete(entity.TypeId);
            repo.Save();

            Assert.IsTrue(testCtx.DiabetesManagementTypes.Count() == --currentCnt);
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
