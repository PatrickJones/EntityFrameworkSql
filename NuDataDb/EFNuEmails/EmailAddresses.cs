using System;
using System.Collections.Generic;

namespace NuDataDb.EFNuEmails
{
    public partial class EmailAddresses
    {
        public int AddressId { get; set; }
        public string Address { get; set; }
        public int EmailType { get; set; }
        public int LocationType { get; set; }
        public int DomainType { get; set; }
    }
}
