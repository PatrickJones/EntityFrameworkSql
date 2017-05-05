using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class DataLinkLog
    {
        public int LinkId { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime Date { get; set; }
        public bool LinkingAction { get; set; }
    }
}
