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
    public class MedicalRecordIdentifiersRepoTest : BaseUnitTest<NuMedicsGlobalContext, MedicalRecordIdentifiers>
    {
        protected MedicalRecordIdentifiersRepo repo;

        protected override void SetContextData()
        {
            repo = new MedicalRecordIdentifiersRepo(testCtx);

            var b = new Faker<MedicalRecordIdentifiers>()
                .RuleFor(r => r.PatientUserId, f => f.Random.Uuid())
                .RuleFor(r => r.InstitutionId, f => f.Random.Uuid());

            var bs = b.Generate(3).ToList();
            FakeCollection.AddRange(bs);

            testCtx.MedicalRecordIdentifiers.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleMedicalRecordIdentifier()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.Id);

            Assert.AreEqual(fakeApp.Id, single.Id);
            Assert.AreEqual(fakeApp.PatientUserId, single.PatientUserId);
            Assert.AreEqual(fakeApp.InstitutionId, single.InstitutionId);

        }

        [TestMethod]
        public void GetSingleIDNotExist()
        {
            var fakeId = 888;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }

        [TestMethod]
        public void DeleteMedicalRecordIdentifier()
        {
            var currentCnt = testCtx.MedicalRecordIdentifiers.Count();

            var entity = testCtx.MedicalRecordIdentifiers.First();
            repo.Delete(entity.Id);
            repo.Save();

            Assert.IsTrue(testCtx.MedicalRecordIdentifiers.Count() == --currentCnt);
        }
        
        [TestMethod]
        public void DeleteIdNotExist()
        {
            var currentCnt = testCtx.MedicalRecordIdentifiers.Count();

            var fakeId = 888;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.MedicalRecordIdentifiers.Count() == currentCnt);
        }
    }
}
