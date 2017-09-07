using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class PatientInstitutionLinkHistory
    {
        public DateTime Date { get; set; }
        public int LinkStatus { get; set; }
        public Guid PatientId { get; set; }
        public Guid InstitutionId { get; set; }
        public int LinkId { get; set; }
    }
}
