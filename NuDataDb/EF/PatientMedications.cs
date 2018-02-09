using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class PatientMedications
    {
        public string Name { get; set; }
        public DateTime LastUpdated { get; set; }
        public int HourlyDosageInterval { get; set; }
        public int DosageTakenDaily { get; set; }
        public Guid UserId { get; set; }
        public int PatientMedicationId { get; set; }
        public string DosageDescription { get; set; }

        public Patients User { get; set; }
    }
}
