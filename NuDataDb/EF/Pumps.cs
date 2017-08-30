using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class Pumps
    {
        public Pumps()
        {
            PumpPrograms = new HashSet<PumpPrograms>();
            PumpSettings = new HashSet<PumpSettings>();
        }

        public string PumpType { get; set; }
        public string PumpName { get; set; }
        public DateTime PumpStartDate { get; set; }
        public string PumpInfusionSet { get; set; }
        public int ActiveProgramId { get; set; }
        public double Cannula { get; set; }
        public DateTime ReplacementDate { get; set; }
        public string Notes { get; set; }
        public Guid UserId { get; set; }
        public Guid PumpKeyId { get; set; }

        public virtual ICollection<PumpPrograms> PumpPrograms { get; set; }
        public virtual ICollection<PumpSettings> PumpSettings { get; set; }
        public virtual ReadingHeaders PumpKey { get; set; }
    }
}
