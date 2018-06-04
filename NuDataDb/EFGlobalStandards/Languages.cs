using System;
using System.Collections.Generic;

namespace NuDataDb.EFGlobalStandards
{
    public partial class Languages
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string TwoLetter { get; set; }
        public string ThreeLetter { get; set; }
    }
}
