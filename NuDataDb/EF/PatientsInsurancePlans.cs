using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class PatientsInsurancePlans
    {
        public Guid UserId { get; set; }
        public int PlanId { get; set; }

        public virtual InsurancePlans Plan { get; set; }
        public virtual Patients User { get; set; }
    }
}
