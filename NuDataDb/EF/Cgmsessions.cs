using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class Cgmsessions
    {
        public DateTime SessionDateTime { get; set; }
        public int TimeInSeconds { get; set; }
        public bool IsActive { get; set; }
        public Guid Cgmid { get; set; }
        public DateTime Date { get; set; }

        public virtual Pumps Cgm { get; set; }
    }
}
