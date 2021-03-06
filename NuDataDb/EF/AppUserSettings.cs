﻿using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class AppUserSettings
    {
        public int AppUserSettingId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string JsonData { get; set; }
        public Guid AppicationId { get; set; }
        public Guid UserId { get; set; }
        public Guid LastUpdatedByUser { get; set; }

        public Applications Appication { get; set; }
    }
}
