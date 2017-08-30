using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PatientLinkLogsRepo : BaseRepo<PatientInstitutionLinkHistory>
    {
        public PatientLinkLogsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        // Cannot get single or delete

    }
}
