using System;
using System.Collections.Generic;
using System.Text;

namespace NuDataDb.EF
{
    public class SubscriptionsView
    {
        public int SubscriptionId { get; set; }
        public Guid UserId { get; set; }
        public int SubscriptionType { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsTrial { get; set; }
        public Guid ApplicationId { get; set; }
        public int UserType { get; set; }
        public Guid InstitutionId { get; set; }
        public int PaymentMethod { get; set; }
        public int PaymentId { get; set; }
        public int? CheckId { get; set; }
        public int? CheckStatus { get; set; }
        public string CheckNumber { get; set; }
        public long? CheckCode { get; set; }
        public DateTime? CheckDateRecieved { get; set; }
        public decimal? CheckAmount { get; set; }
        public int? PayPalId { get; set; }
        public DateTime? PayPalPaymentDate { get; set; }
        public string PayPalPaymentStatus { get; set; }
        public decimal? PayPalPayment { get; set; }
    }
}
