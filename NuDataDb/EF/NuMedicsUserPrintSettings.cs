using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class NuMedicsUserPrintSettings
    {
        public int PrintSettingId { get; set; }
        public Guid UserId { get; set; }
        public Guid SettingsApplyToUser { get; set; }
        public string JsonPrintSettings { get; set; }
    }
}
