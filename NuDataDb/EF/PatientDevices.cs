using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class PatientDevices
    {
        public PatientDevices()
        {
            ReadingHeaders = new HashSet<ReadingHeaders>();
        }

        public int DeviceId { get; set; }
        public Guid UserId { get; set; }
        public int MeterIndex { get; set; }
        public string Manufacturer { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceName { get; set; }
        public string SerialNumber { get; set; }
        public string SoftwareVersion { get; set; }
        public string HardwareVersion { get; set; }

        public virtual DeviceData DeviceData { get; set; }
        public virtual DiabetesManagementData DiabetesManagementData { get; set; }
        public virtual ICollection<ReadingHeaders> ReadingHeaders { get; set; }
        public virtual Patients User { get; set; }
    }
}
