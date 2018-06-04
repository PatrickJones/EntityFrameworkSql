using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class SubscriptionType
    {
        public int SubscriptionTypeId { get; set; }
        public Guid ApplicationId { get; set; }
        public int SubscriptionLengthDays { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
