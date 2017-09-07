using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class BolusCarbs
    {
        public int CarbId { get; set; }
        public int CarbValue { get; set; }
        public DateTime Date { get; set; }

        public BolusDeliveries Carb { get; set; }
    }
}
