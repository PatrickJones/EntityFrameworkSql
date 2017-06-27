using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class InstitutionsRepo : BaseRepo<Institutions>
    {
        public InstitutionsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Institutions GetSingle(Guid id)
        {
            return ctx.Institutions.FirstOrDefault(f => f.InstitutionId == id);
        }

        public override void Delete(Guid id)
        {
            var del = ctx.Institutions.FirstOrDefault(f => f.InstitutionId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
