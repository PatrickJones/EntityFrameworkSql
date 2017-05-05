using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class PatientLinkLogs
    {
        public int LinkId { get; set; }
        public Guid UserId { get; set; }
        public Guid InstitutionId { get; set; }
        public DateTime LinkCreationDate { get; set; }
        public DateTime LinkSeverDate { get; set; }
        public bool HasFreeDownload { get; set; }
    }
}
