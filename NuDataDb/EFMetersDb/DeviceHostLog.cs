using System;
using System.Collections.Generic;

namespace NuDataDb.EFMetersDb
{
    public partial class DeviceHostLog
    {
        public int LogId { get; set; }
        public Guid DeviceHostId { get; set; }
        public Guid UserId { get; set; }
        public int DeviceIdInvoked { get; set; }
        public string Message { get; set; }
        public int LogMessageType { get; set; }
        public DateTime LogDate { get; set; }
        public int LogMessageCode { get; set; }

        public DeviceHost DeviceHost { get; set; }
    }
}
