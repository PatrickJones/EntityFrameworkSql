using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class CareSettings
    {
        public CareSettings()
        {
            DailyTimeSlots = new HashSet<DailyTimeSlots>();
            DiabetesControlTypes = new HashSet<DiabetesControlTypes>();
        }

        public int CareSettingsId { get; set; }
        public Guid UserId { get; set; }
        public int HyperglycemicLevel { get; set; }
        public int HypoglycemicLevel { get; set; }
        public int InsulinMethod { get; set; }
        public int DiabetesManagementType { get; set; }
        public int InsulinBrand { get; set; }
        public DateTime DateModified { get; set; }
        public Guid LastUpdatedByUser { get; set; }

        public virtual ICollection<DailyTimeSlots> DailyTimeSlots { get; set; }
        public virtual ICollection<DiabetesControlTypes> DiabetesControlTypes { get; set; }
        public virtual Patients User { get; set; }
    }
}
