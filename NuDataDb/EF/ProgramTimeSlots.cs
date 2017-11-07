using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class ProgramTimeSlots
    {
        public int SlotId { get; set; }
        public double Value { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan StopTime { get; set; }
        public int PumpProgramId { get; set; }
        public DateTime DateSet { get; set; }

        public PumpPrograms PumpProgram { get; set; }
    }
}
