using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class AppSettings
    {
        public int AppSettingId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string JsonData { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid LastUpdatedbyUser { get; set; }

        public Applications Application { get; set; }
    }
}
