using System;
using System.Collections.Generic;
using System.Text;

namespace NuDataDb.EF
{
    public partial class EndUserLicenseAgreements
    {
        public int AgreementId { get; set; }
        public Guid UserId { get; set; }
        public DateTime AgreementDate { get; set; }
        public Guid ApplicationId { get; set; }

        public virtual Applications Application { get; set; }
    }
}
