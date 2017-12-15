using System;
using System.Collections.Generic;
using System.Text;

namespace NuDataDb.EF
{
    public class PatientInsurance
    {
        public int PatientInsuranceId { get; set; }
        public string ProviderName { get; set; }
        public string PolicyNumber { get; set; }
        public string PlanIdentifier { get; set; }
        public string GroupIdentifier { get; set; }
        public Guid UserId { get; set; }

        public Patients User { get; set; }
    }
}
