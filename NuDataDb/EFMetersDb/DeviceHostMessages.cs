using System;
using System.Collections.Generic;

namespace NuDataDb.EFMetersDb
{
    public partial class DeviceHostMessages
    {
        public int MessageId { get; set; }
        public string Message { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
