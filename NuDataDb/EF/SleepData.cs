using System;
using System.Collections.Generic;
using System.Text;

namespace NuDataDb.EF
{
    public partial class SleepData
    {
        public int SleepDataId { get; set; }
        public DateTime SleepDateTime { get; set; }
        public int SleepStageLevel { get; set; }
        public int SleepPatternLevel { get; set; }
        public int Seconds { get; set; }
        public int SleepReadingId { get; set; }
        public Guid UserId { get; set; }

        public SleepReadings SleepReading { get; set; }
    }
}
