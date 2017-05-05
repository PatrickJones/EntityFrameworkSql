using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class BolusDelivery
    {
        public BolusDelivery()
        {
            BolusDeliveryData = new HashSet<BolusDeliveryData>();
        }

        public int BolusDeliveryId { get; set; }
        public DateTime StartDateTime { get; set; }
        public double AmountDelivered { get; set; }
        public double AmountSuggested { get; set; }
        public int Duration { get; set; }
        public string BolusTrigger { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public Guid ReadingKeyId { get; set; }
        public Guid UserId { get; set; }

        public virtual Bgtargets Bgtargets { get; set; }
        public virtual BolusCarbs BolusCarbs { get; set; }
        public virtual ICollection<BolusDeliveryData> BolusDeliveryData { get; set; }
        public virtual CorrectionFactors CorrectionFactors { get; set; }
        public virtual InsulinCarbRatio InsulinCarbRatio { get; set; }
        public virtual InsulinCorrections InsulinCorrections { get; set; }
        public virtual ReadingHeaders ReadingKey { get; set; }
    }
}
