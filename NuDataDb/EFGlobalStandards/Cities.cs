using System;
using System.Collections.Generic;

namespace NuDataDb.EFGlobalStandards
{
    public partial class Cities
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string AccentName { get; set; }
        public string TimeZone { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int StateId { get; set; }

        public States State { get; set; }
    }
}
