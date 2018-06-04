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
    public class InstitutionAddressRepoTest : BaseUnitTest<NuMedicsGlobalContext,InstitutionAddresses>
    {
        protected InstitutionAddressRepo repo;

        protected override void SetContextData()
        {
            repo = new InstitutionAddressRepo(testCtx);

            var b = new Faker<InstitutionAddresses>()
                .RuleFor(r => r.Street1, f => f.Lorem.Letter(250))
                .RuleFor(r => r.Street2, f => f.Lorem.Letter(250))
                .RuleFor(r => r.Street3, f => f.Lorem.Letter(250))
                .RuleFor(r => r.City, f => f.Lorem.Letter(250))
                .RuleFor(r => r.State, f => f.Lorem.Letter(250))
                .RuleFor(r => r.Zip, f => f.Lorem.Letter(50))
                .RuleFor(r => r.Country, f => f.Lorem.Letter(250))
                .RuleFor(r => r.InstitutionId, f => f.Random.Uuid())
                .RuleFor(r => r.LastUpdatedByUser, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.AddressId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.InstitutionAddresses.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleInstitutionAddresses()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.AddressId);

            Assert.AreEqual(fakeApp.AddressId, single.AddressId);
            Assert.AreEqual(fakeApp.Street1, single.Street1);
            Assert.AreEqual(fakeApp.City, single.City);
            Assert.AreEqual(fakeApp.State, single.State);
            Assert.AreEqual(fakeApp.Zip, single.Zip);
            Assert.AreEqual(fakeApp.Country, single.Country);
            Assert.AreEqual(fakeApp.InstitutionId, single.InstitutionId);
            Assert.AreEqual(fakeApp.LastUpdatedByUser, single.LastUpdatedByUser);
        }

        [TestMethod]
        public void GetSingleAddressIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteInstitutionAddresses()
        {
            var currentCnt = testCtx.InstitutionAddresses.Count();

            var entity = testCtx.InstitutionAddresses.First();
            repo.Delete(entity.AddressId);
            repo.Save();

            Assert.IsTrue(testCtx.InstitutionAddresses.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeleteAddressIdNotExist()
        {
            var currentCnt = testCtx.InstitutionAddresses.Count();

            var fakeId = 842;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.InstitutionAddresses.Count() == currentCnt);
        }
    }
}
