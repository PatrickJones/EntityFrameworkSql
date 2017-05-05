using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class DeviceSettings
    {
        public int SettingId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public Guid ReadingKeyId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateSet { get; set; }

        public virtual ReadingHeaders ReadingKey { get; set; }
    }
}
