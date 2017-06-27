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
    public class ChecksnRepoTest : BaseUnitTest<Checks>
    {
        //Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected ChecksRepo repo;

        protected override void SetContextData()
        {
            repo = new ChecksRepo(testCtx);

            var b = new Faker<Checks>()
                .RuleFor(r => r.CheckId, f => itrtr32++)
                .RuleFor(r => r.CheckStatus, f => f.Random.Int())
                .RuleFor(r => r.CheckNumber, f => f.Lorem.Word())
                .RuleFor(r => r.CheckCode, f => f.Random.Long())
                .RuleFor(r => r.CheckDateRecieved, f => new DateTime(f.Random.Long()))
                .RuleFor(r => r.CheckAmount, f => f.Random.Decimal());

            var bs = b.Generate(3).OrderBy(o => o.CheckId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.Checks.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleChecks()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.CheckId);

            Assert.AreEqual(fakeApp.CheckId, single.CheckId);
            Assert.AreEqual(fakeApp.CheckNumber, single.CheckNumber);
        }

        public void GetSingleCheckIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteChecks()
        {
            var currentCnt = testCtx.Checks.Count();

            var entity = testCtx.Checks.First();
            repo.Delete(entity.CheckId);
            repo.Save();

            Assert.IsTrue(testCtx.Checks.Count() == --currentCnt);
        }

        public void DeleteCheckIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
