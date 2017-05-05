using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class CorrectionFactors
    {
        public int FactorId { get; set; }
        public int CorrectionFactorValue { get; set; }
        public DateTime Date { get; set; }

        public virtual BolusDelivery Factor { get; set; }
    }
}
