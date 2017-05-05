﻿using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class Subscriptions
    {
        public int SubscriptionId { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid UserId { get; set; }
        public int UserType { get; set; }
        public int SubscriptionType { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsTrial { get; set; }
        public Guid InstitutionId { get; set; }

        public virtual Payments Payments { get; set; }
        public virtual Institutions Institution { get; set; }
        public virtual Patients User { get; set; }
    }
}
