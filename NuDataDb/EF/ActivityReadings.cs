using System;
using System.Collections.Generic;
using System.Text;

namespace NuDataDb.EF
{
    public partial class ActivityReadings
    {
        public int ActivityReadingId { get; set; }
        public int ActivityType { get; set; }
        public DateTime ActivityDate { get; set; }
        public long Duration { get; set; }
        public DateTime StartTime { get; set; }
        public Guid UserId { get; set; }
        public Guid ReadingKeyId { get; set; }

        public ReadingHeaders ReadingKey { get; set; }
    }
}
