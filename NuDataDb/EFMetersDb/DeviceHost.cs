using System;
using System.Collections.Generic;

namespace NuDataDb.EFMetersDb
{
    public partial class DeviceHost
    {
        public DeviceHost()
        {
            DeviceHostLog = new HashSet<DeviceHostLog>();
        }

        public Guid DeviceHostId { get; set; }
        public DateTime InstallDate { get; set; }
        public DateTime? UnInstallDate { get; set; }
        public int SiteId { get; set; }
        public int Status { get; set; }
        public string Macaddress { get; set; }
        public string IpAddress { get; set; }
        public string ComputerName { get; set; }
        public bool? IsInstitution { get; set; }

        public ICollection<DeviceHostLog> DeviceHostLog { get; set; }
    }
}
