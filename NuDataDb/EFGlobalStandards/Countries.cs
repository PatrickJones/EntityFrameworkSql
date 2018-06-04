using System;
using System.Collections.Generic;

namespace NuDataDb.EFGlobalStandards
{
    public partial class Countries
    {
        public Countries()
        {
            States = new HashSet<States>();
        }

        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public int ContinentId { get; set; }

        public Continents Continent { get; set; }
        public ICollection<States> States { get; set; }
    }
}
