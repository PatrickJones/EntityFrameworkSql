﻿using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class BasalDeliveries
    {
        public BasalDeliveries()
        {
            BasalDeliveryData = new HashSet<BasalDeliveryData>();
        }

        public int BasalDeliveryId { get; set; }
        public int AmountDelivered { get; set; }
        public double DeliveryRate { get; set; }
        public bool IsTemp { get; set; }
        public string Duration { get; set; }
        public DateTime StartDateTime { get; set; }
        public Guid ReadingKeyId { get; set; }
        public Guid UserId { get; set; }

        public ReadingHeaders ReadingHeader { get; set; }
        public ICollection<BasalDeliveryData> BasalDeliveryData { get; set; }
    }
}
