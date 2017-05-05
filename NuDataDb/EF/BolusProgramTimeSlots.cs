using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class BolusProgramTimeSlots
    {
        public int BolusSlotId { get; set; }
        public double BolusValue { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan StopTime { get; set; }
        public int PumpProgramId { get; set; }
        public DateTime DateSet { get; set; }

        public virtual PumpPrograms PumpProgram { get; set; }
    }
}
