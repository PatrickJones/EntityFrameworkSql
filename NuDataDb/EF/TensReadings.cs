﻿using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class TensReadings
    {
        public int ReadingId { get; set; }
        public DateTime ReadingDate { get; set; }
        public string StartTime { get; set; }
        public int TherapyType { get; set; }
        public int DurationScheduled { get; set; }
        public int DurationCompleted { get; set; }
        public int Aplitude { get; set; }
        public int PulseWidth { get; set; }
        public int Frequency { get; set; }
        public Guid ReadingKeyId { get; set; }
        public Guid UserId { get; set; }

        public ReadingHeaders ReadingHeader { get; set; }
    }
}
