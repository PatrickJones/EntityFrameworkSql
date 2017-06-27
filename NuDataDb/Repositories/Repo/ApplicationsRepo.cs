using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class ApplicationsRepo : BaseRepo<Applications>
    {
        public ApplicationsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Applications GetSingle(Guid id)
        {
            return ctx.Applications.FirstOrDefault(f => f.ApplicationId == id);
        }

        public override void Delete(Guid id)
        {
            var del = ctx.Applications.FirstOrDefault(f => f.ApplicationId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
