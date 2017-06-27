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
    public class CGMSessionsnRepoTest : BaseUnitTest<Cgmsessions>
    {
        //Int64 itrtr64 = 0;
        //int itrtr32 = 0;

        protected CGMSessionsRepo repo;

        protected override void SetContextData()
        {
            repo = new CGMSessionsRepo(testCtx);

            var b = new Faker<Cgmsessions>()
                .RuleFor(r => r.Cgmid, f => f.Random.Uuid())
                .RuleFor(r => r.SessionDateTime, f => new DateTime(f.Random.Long()))
                .RuleFor(r => r.TimeInSeconds, f => f.Random.Int())
                .RuleFor(r => r.IsActive, f => f.Random.Bool())
                .RuleFor(r => r.Date, f => new DateTime(f.Random.Long()));

            var bs = b.Generate(3).OrderBy(o => o.Cgmid).ToList();
            FakeCollection.AddRange(bs);


            testCtx.Cgmsessions.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleCGMSessions()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.Cgmid);

            Assert.AreEqual(fakeApp.Cgmid, single.Cgmid);
            Assert.AreEqual(fakeApp.SessionDateTime, single.SessionDateTime);
        }

        public void GetSingleCGMIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteCGMSessions()
        {
            var currentCnt = testCtx.Cgmsessions.Count();

            var entity = testCtx.Cgmsessions.First();
            repo.Delete(entity.Cgmid);
            repo.Save();

            Assert.IsTrue(testCtx.Cgmsessions.Count() == --currentCnt);
        }

        public void DeleteCGMIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = Guid.NewGuid();
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
