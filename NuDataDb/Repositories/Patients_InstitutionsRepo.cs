using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PatientsInstitutionsRepo : BaseRepo<PatientsInstitutions>
    {
        public PatientsInstitutionsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PatientsInstitutions GetSingle(Guid id)
        {
            return ctx.PatientsInstitutions.FirstOrDefault(f => f.UserId == id);
        }

        public override void Delete(Guid id)
        {
            var del = ctx.PatientsInstitutions.FirstOrDefault(f => f.UserId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
