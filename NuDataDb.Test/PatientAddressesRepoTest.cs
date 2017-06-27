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
    public class PatientAddressesnRepoTest : BaseUnitTest<PatientAddresses>
    {
        //Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected PatientAddressesRepo repo;

        protected override void SetContextData()
        {
            repo = new PatientAddressesRepo(testCtx);

            var b = new Faker<PatientAddresses>()
                .RuleFor(r => r.AddressId, f => itrtr32++)
                .RuleFor(r => r.Street1, f => f.Lorem.Letter(250))
                .RuleFor(r => r.City, f => f.Lorem.Letter(250))
                .RuleFor(r => r.State, f => f.Lorem.Letter(250))
                .RuleFor(r => r.Zip, f => f.Lorem.Letter(50))
                .RuleFor(r => r.Country, f => f.Lorem.Letter(250))
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.LastUpdatedByUser, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.AddressId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.PatientAddresses.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSinglePatientAddresses()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.AddressId);

            Assert.AreEqual(fakeApp.AddressId, single.AddressId);
            Assert.AreEqual(fakeApp.Street1, single.Street1);
            Assert.AreEqual(fakeApp.City, single.City);
            Assert.AreEqual(fakeApp.State, single.State);
            Assert.AreEqual(fakeApp.Zip, single.Zip);
            Assert.AreEqual(fakeApp.Country, single.Country);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.LastUpdatedByUser, single.LastUpdatedByUser);
        }

        public void GetSingleAddressIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeletePatientAddresses()
        {
            var currentCnt = testCtx.PatientAddresses.Count();

            var entity = testCtx.PatientAddresses.First();
            repo.Delete(entity.AddressId);
            repo.Save();

            Assert.IsTrue(testCtx.PatientAddresses.Count() == --currentCnt);
        }

        public void DeleteAddressIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
