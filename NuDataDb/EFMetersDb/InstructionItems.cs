using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NuDataDb.EFMetersDb
{
    public partial class InstructionItems
    {
        public int Id { get; set; }
        public int StepNumber { get; set; }
        [StringLength(4000)]
        public string Instruction { get; set; }
        public int MeterId { get; set; }

        public Meters Meter { get; set; }
    }
}
