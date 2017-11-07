using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class PumpPrograms
    {
        public PumpPrograms()
        {
            ProgramTimeSlots = new HashSet<ProgramTimeSlots>();
        }

        public int PumpProgramId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Source { get; set; }
        public string ProgramName { get; set; }
        public int ProgramKey { get; set; }
        public bool? Valid { get; set; }
        public int NumOfSegments { get; set; }
        public Guid PumpKeyId { get; set; }
        public bool IsEnabled { get; set; }
        public int ProgramTypeId { get; set; }

        public Pumps PumpKey { get; set; }
        public ICollection<ProgramTimeSlots> ProgramTimeSlots { get; set; }
    }
}
