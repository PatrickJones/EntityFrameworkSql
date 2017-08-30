using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class Bgtargets
    {
        public int TargetId { get; set; }
        public int TargetBg { get; set; }
        public int TargetBgcorrect { get; set; }
        public DateTime Date { get; set; }

        public virtual BolusDeliveries Target { get; set; }
    }
}
