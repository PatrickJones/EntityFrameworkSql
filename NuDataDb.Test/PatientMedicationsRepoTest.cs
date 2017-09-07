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
    public class PatientMedicationsRepoTest : BaseUnitTest<PatientMedications>
    {
        protected PatientMedicationsRepo repo;

        protected override void SetContextData()
        {
            repo = new PatientMedicationsRepo(testCtx);

            var b = new Faker<PatientMedications>()
                .RuleFor(r => r.DosageTakenDaily, f => f.Random.Int(1,4))
                .RuleFor(r => r.HourlyDosageInterval, f => f.Random.Int(1, 4))
                .RuleFor(r => r.LastUpdated, f => f.Date.Past())
                .RuleFor(r => r.MedicationId, f => f.Random.Long())
                .RuleFor(r => r.Name, f => f.Lorem.Word())
                .RuleFor(r => r.UserId, f => f.Random.Uuid());

            var bs = b.Generate(3).OrderBy(o => o.PatientMedicationId).ToList();
            FakeCollection.AddRange(bs);

            testCtx.PatientMedications.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSinglePatientMedication()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.PatientMedicationId);

            Assert.AreEqual(fakeApp.DosageTakenDaily, single.DosageTakenDaily);
            Assert.AreEqual(fakeApp.HourlyDosageInterval, single.HourlyDosageInterval);
            Assert.AreEqual(fakeApp.LastUpdated, single.LastUpdated);
            Assert.AreEqual(fakeApp.MedicationId, single.MedicationId);
            Assert.AreEqual(fakeApp.Name, single.Name);
            Assert.AreEqual(fakeApp.UserId, single.UserId);
            Assert.AreEqual(fakeApp.PatientMedicationId, single.PatientMedicationId);
        }

        [TestMethod]
        public void GetSinglePatientMedicationIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeletePatientMedication()
        {
            var currentCnt = testCtx.PatientMedications.Count();

            var entity = testCtx.PatientMedications.First();
            repo.Delete(entity.PatientMedicationId);
            repo.Save();

            Assert.IsTrue(testCtx.PatientMedications.Count() == --currentCnt);
        }

        [TestMethod]
        public void DeletePatientMedicationIdNotExist()
        {
            var currentCnt = testCtx.PatientMedications.Count();

            var fakeId = 842;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.PatientMedications.Count() == currentCnt);
        }
    }
}
