using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class DailyTimeSlots
    {
        public int TimeSlotId { get; set; }
        public string TimeSlotDescription { get; set; }
        public TimeSpan TimeSlotBoundary { get; set; }
        public int CareSettingsId { get; set; }
        public Guid LastUpdatedByUser { get; set; }

        public virtual CareSettings CareSettings { get; set; }
    }
}
