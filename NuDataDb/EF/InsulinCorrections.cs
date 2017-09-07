using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class InsulinCorrections
    {
        public int CorrectionId { get; set; }
        public int InsulinCorrectionValue { get; set; }
        public DateTime Date { get; set; }
        public int InsulinCorrectionAbove { get; set; }

        public BolusDeliveries Correction { get; set; }
    }
}
