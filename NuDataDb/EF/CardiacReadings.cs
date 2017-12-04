using System;
using System.Collections.Generic;
using System.Text;

namespace NuDataDb.EF
{
    public partial class CardiacReadings
    {
        public int CardiacReadingId { get; set; }
        public int HeartRate { get; set; }
        public int Steps { get; set; }
        public bool IsECG { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public long Duration { get; set; }
        public Guid UserId { get; set; }
        public Guid ReadingKeyId { get; set; }
        public int ActivityType { get; set; }

        public ReadingHeaders ReadingHeader { get; set; }
    }
}
