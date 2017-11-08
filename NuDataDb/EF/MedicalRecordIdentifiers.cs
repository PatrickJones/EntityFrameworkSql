using System;
using System.Collections.Generic;
using System.Text;

namespace NuDataDb.EF
{
    public partial class MedicalRecordIdentifiers
    {
        public int Id { get; set; }
        public Guid PatientUserId { get; set; }
        public string MRID { get; set; }
        public Guid InstitutionId { get; set; }

        public Institutions Institution { get; set; }
    }
}
