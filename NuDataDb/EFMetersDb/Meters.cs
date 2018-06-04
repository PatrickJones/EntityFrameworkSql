using System;
using System.Collections.Generic;

namespace NuDataDb.EFMetersDb
{
    public partial class Meters
    {
        public Meters()
        {
            InstructionItems = new HashSet<InstructionItems>();
        }

        public int Id { get; set; }
        public string ExternalId { get; set; }
        public string MeterName { get; set; }
        public string MeterModel { get; set; }
        public string MeterManufacturer { get; set; }
        public string MeterVid { get; set; }
        public string MeterPid { get; set; }
        public string MeterImageName { get; set; }
        public int MeterDelphiIndex { get; set; }
        public string MeterDelphiName { get; set; }
        public bool? InsuletMarket { get; set; }
        public bool? CurrentlyActive { get; set; }
        public string MeterClass { get; set; }
        public string Corporation { get; set; }
        public bool IsPump { get; set; }
        public bool IsFitness { get; set; }
        public string Trademark { get; set; }

        public ICollection<InstructionItems> InstructionItems { get; set; }
    }
}
