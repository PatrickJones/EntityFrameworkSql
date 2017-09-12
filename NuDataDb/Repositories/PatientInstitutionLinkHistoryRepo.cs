using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PatientInstitutionLinkHistoryRepo : BaseRepo<PatientInstitutionLinkHistory, NuMedicsGlobalContext>
    {
        public PatientInstitutionLinkHistoryRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        // Cannot get single or delete

    }
}
