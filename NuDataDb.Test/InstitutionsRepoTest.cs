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
    public class InstitutionsnRepoTest : BaseUnitTest<Institutions>
    {
        protected InstitutionsRepo repo;

        protected override void SetContextData()
        {
            repo = new InstitutionsRepo(testCtx);

            var b = new Faker<Institutions>()
                .RuleFor(r => r.InstitutionId, f => f.Random.Uuid())
                .RuleFor(r => r.Name, f => f.Lorem.Letter(250))
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.LegacySiteId, f => f.Random.Int())
                .RuleFor(r => r.Licenses, f => f.Random.Int())
                .RuleFor(r => r.LastUpdatedByUser, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.InstitutionId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.Institutions.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingleInstitutions()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.InstitutionId);

            Assert.AreEqual(fakeApp.InstitutionId, single.InstitutionId);
            Assert.AreEqual(fakeApp.Name, single.Name);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.LegacySiteId, single.LegacySiteId);
            Assert.AreEqual(fakeApp.Licenses, single.Licenses);
            Assert.AreEqual(fakeApp.LastUpdatedByUser, single.LastUpdatedByUser);
        }

        [TestMethod]
        public void GetSingleInstitutionIdNotExist()
        {
            var fakeId = Guid.NewGuid();
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteInstitutions()
        {
            var currentCnt = testCtx.Institutions.Count();

            var entity = testCtx.Institutions.First();
            repo.Delete(entity.InstitutionId);
            repo.Save();

            Assert.IsTrue(testCtx.Institutions.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteInstitutionIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = Guid.NewGuid();
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
