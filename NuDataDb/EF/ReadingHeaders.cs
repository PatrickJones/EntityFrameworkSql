using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class ReadingHeaders
    {
        public ReadingHeaders()
        {
            BasalDeliveries = new HashSet<BasalDeliveries>();
            BloodGlucoseReadings = new HashSet<BloodGlucoseReadings>();
            BolusDelivery = new HashSet<BolusDelivery>();
            DeviceSettings = new HashSet<DeviceSettings>();
            NutritionReadings = new HashSet<NutritionReadings>();
            PhysiologicalReadings = new HashSet<PhysiologicalReadings>();
            ReadingErrors = new HashSet<ReadingErrors>();
            ReadingEvents = new HashSet<ReadingEvents>();
            TensReadings = new HashSet<TensReadings>();
            TotalDailyInsulinDeliveries = new HashSet<TotalDailyInsulinDeliveries>();
        }

        public int DeviceId { get; set; }
        public DateTime ServerDateTime { get; set; }
        public DateTime MeterDateTime { get; set; }
        public int Readings { get; set; }
        public string SiteSource { get; set; }
        public DateTime ReviewedOn { get; set; }
        public bool IsCgmdata { get; set; }
        public Guid UserId { get; set; }
        public string LegacyDownloadKeyId { get; set; }
        public Guid ReadingKeyId { get; set; }

        public virtual ICollection<BasalDeliveries> BasalDeliveries { get; set; }
        public virtual ICollection<BloodGlucoseReadings> BloodGlucoseReadings { get; set; }
        public virtual ICollection<BolusDelivery> BolusDelivery { get; set; }
        public virtual ICollection<DeviceSettings> DeviceSettings { get; set; }
        public virtual ICollection<NutritionReadings> NutritionReadings { get; set; }
        public virtual ICollection<PhysiologicalReadings> PhysiologicalReadings { get; set; }
        public virtual Pumps Pumps { get; set; }
        public virtual ICollection<ReadingErrors> ReadingErrors { get; set; }
        public virtual ICollection<ReadingEvents> ReadingEvents { get; set; }
        public virtual ICollection<TensReadings> TensReadings { get; set; }
        public virtual ICollection<TotalDailyInsulinDeliveries> TotalDailyInsulinDeliveries { get; set; }
        public virtual PatientDevices Device { get; set; }
    }
}
