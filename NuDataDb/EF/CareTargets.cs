using System;
using System.Collections.Generic;
using System.Text;

namespace NuDataDb.EF
{
    public partial class CareTargets
    {
        public int CareTargetId { get; set; }
        public int TargetCaloriesPerDay { get; set; }
        public long TargetStepsperDay { get; set; }
        public Guid UserId { get; set; }
        public int CareSettingsId { get; set; }

        public CareSettings CareSettings { get; set; }
    }
}
