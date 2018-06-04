using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class InsulinBrands
    {
        public int InsulinBrandId { get; set; }
        public string BrandName { get; set; }
        public string Manufacturer { get; set; }
        public int InsulinType { get; set; }
    }
}
