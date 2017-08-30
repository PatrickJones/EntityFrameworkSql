using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class PatientInstitutionLinkHistory
    {
        public Guid PatientId { get; set; }
        public Guid InstitutionId { get; set; }
        public DateTime Date { get; set; }
        public int LinkStatus { get; set; }
    }
}
