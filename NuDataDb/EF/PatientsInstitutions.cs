using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class PatientsInstitutions
    {
        public Guid UserId { get; set; }
        public Guid InstitutionId { get; set; }

        public virtual Institutions Institution { get; set; }
        public virtual Patients User { get; set; }
    }
}
