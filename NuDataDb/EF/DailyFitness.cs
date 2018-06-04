using System;
using System.Collections.Generic;
using System.Text;

namespace NuDataDb.EF
{
    public partial class DailyFitness
    {
        public int DailyFitnessId { get; set; }
        public string ActivityName { get; set; }
        public string ActivityStart { get; set; }
        public string ActivityStop { get; set; }
        public Guid UserId { get; set; }
        public int CareSettingsId { get; set; }

        public CareSettings CareSettings { get; set; }

    }
}
