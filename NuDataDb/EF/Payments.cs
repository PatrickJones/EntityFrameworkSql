using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class Payments
    {
        public int PaymentId { get; set; }
        public int PaymentMethod { get; set; }
        public bool PaymentApproved { get; set; }
        public DateTime ApprovalDate { get; set; }

        public virtual Checks Checks { get; set; }
        public virtual PayPal PayPal { get; set; }
        public virtual Subscriptions Payment { get; set; }
    }
}
