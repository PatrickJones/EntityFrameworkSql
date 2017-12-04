using System;
using System.Collections.Generic;
using System.Text;

namespace NuDataDb.EF
{
    public partial class SleepReadings
    {
        public SleepReadings()
        {
            SleepData = new HashSet<SleepData>();
        }

        public int SleepReadingId { get; set; }
        public long Duration { get; set; }
        public string Efficiency { get; set; }
        public bool IsMainSleep { get; set; }
        public int MinutesAfterWakeup { get; set; }
        public int MinutesAsleep { get; set; }
        public int MinutesToFallAsleep { get; set; }
        public DateTime StartTime { get; set; }
        public int TimeInBed { get; set; }
        public Guid ReadingKeyId { get; set; }
        public Guid UserId { get; set; }

        public ReadingHeaders ReadingKey { get; set; }

        public ICollection<SleepData> SleepData { get; set; }
    }
}
