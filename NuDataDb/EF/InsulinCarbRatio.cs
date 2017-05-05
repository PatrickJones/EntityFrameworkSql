using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class InsulinCarbRatio
    {
        public int RatioId { get; set; }
        public int Icratio { get; set; }
        public DateTime Date { get; set; }

        public virtual BolusDelivery Ratio { get; set; }
    }
}
