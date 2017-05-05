using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class ReadingEvents
    {
        public int Eventid { get; set; }
        public int EventType { get; set; }
        public string EventValue { get; set; }
        public DateTime EventTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ResumeTime { get; set; }
        public DateTime StopTime { get; set; }
        public Guid ReadingKeyId { get; set; }
        public Guid UserId { get; set; }

        public virtual ReadingHeaders ReadingKey { get; set; }
    }
}
