using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class DeviceData
    {
        public int DataSetId { get; set; }
        public string DataSet { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual PatientDevices DataSetNavigation { get; set; }
    }
}
