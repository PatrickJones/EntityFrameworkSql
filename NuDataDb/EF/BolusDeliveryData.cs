﻿using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class BolusDeliveryData
    {
        public int DataId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int BolusDeliveryId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public virtual BolusDelivery BolusDelivery { get; set; }
    }
}
