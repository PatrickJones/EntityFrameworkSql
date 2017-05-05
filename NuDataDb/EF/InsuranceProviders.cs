using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class InsuranceProviders
    {
        public InsuranceProviders()
        {
            InsuranceAddresses = new HashSet<InsuranceAddresses>();
            InsuranceContacts = new HashSet<InsuranceContacts>();
            InsurancePlans = new HashSet<InsurancePlans>();
        }

        public int CompanyId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? InActiveDate { get; set; }
        public Guid LastUpdatedByUser { get; set; }

        public virtual ICollection<InsuranceAddresses> InsuranceAddresses { get; set; }
        public virtual ICollection<InsuranceContacts> InsuranceContacts { get; set; }
        public virtual ICollection<InsurancePlans> InsurancePlans { get; set; }
    }
}
