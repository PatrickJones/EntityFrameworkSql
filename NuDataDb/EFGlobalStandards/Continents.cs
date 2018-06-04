using System;
using System.Collections.Generic;

namespace NuDataDb.EFGlobalStandards
{
    public partial class Continents
    {
        public Continents()
        {
            Countries = new HashSet<Countries>();
        }

        public int ContinentId { get; set; }
        public string ContinentCode { get; set; }
        public string Name { get; set; }

        public ICollection<Countries> Countries { get; set; }
    }
}
