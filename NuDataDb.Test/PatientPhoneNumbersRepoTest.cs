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
    public class PatientPhoneNumbersnRepoTest : BaseUnitTest<PatientPhoneNumbers>
    {
        Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected PatientPhoneNumbersRepo repo;

        protected override void SetContextData()
        {
            repo = new PatientPhoneNumbersRepo(testCtx);

            var b = new Faker<PatientPhoneNumbers>()
                .RuleFor(r => r.PhoneId, f => itrtr32++)
                .RuleFor(r => r.Number, f => f.Lorem.Letter(50))
                .RuleFor(r => r.Type, f => f.Random.Int())
                .RuleFor(r => r.IsPrimary, f => f.Random.Bool())
                .RuleFor(r => r.RecieveText, f => f.Random.Bool())
                .RuleFor(r => r.UserId, f => f.Random.Uuid())
                .RuleFor(r => r.LastUpdatedByUser, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.PhoneId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.PatientPhoneNumbers.AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSinglePatientPhoneNumbers()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.PhoneId);

            Assert.AreEqual(fakeApp.PhoneId, single.PhoneId);
            Assert.AreEqual(fakeApp.Number, single.Number);
            Assert.AreEqual(fakeApp.Type, single.Type);
            Assert.AreEqual(fakeApp.IsPrimary, single.IsPrimary);
            Assert.AreEqual(fakeApp.RecieveText, single.RecieveText);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.LastUpdatedByUser, single.LastUpdatedByUser);
        }

        public void GetSinglePhoneIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeletePatientPhoneNumbers()
        {
            var currentCnt = testCtx.PatientPhoneNumbers.Count();

            var entity = testCtx.PatientPhoneNumbers.First();
            repo.Delete(entity.PhoneId);
            repo.Save();

            Assert.IsTrue(testCtx.PatientPhoneNumbers.Count() == --currentCnt);
        }

        public void DeletePhoneIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
