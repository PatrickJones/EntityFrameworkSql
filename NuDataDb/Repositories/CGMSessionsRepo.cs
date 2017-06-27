using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class CGMSessionsRepo : BaseRepo<Cgmsessions>
    {
        public CGMSessionsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Cgmsessions GetSingle(Guid id)
        {
            return ctx.Cgmsessions.FirstOrDefault(f => f.Cgmid == id);
        }

        public override void Delete(Guid id)
        {
            var del = ctx.Cgmsessions.FirstOrDefault(f => f.Cgmid == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
