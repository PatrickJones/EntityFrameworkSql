using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class Clinicians
    {
        public Guid UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string StateLicenseNumber { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid LastUpdatedByUser { get; set; }
        public string Email { get; set; }

        public virtual Institutions Institution { get; set; }
        public virtual Users User { get; set; }
    }
}
