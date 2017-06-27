using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class ChecksRepo : BaseRepo<Checks>
    {
        public ChecksRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Checks GetSingle(int id)
        {
            return ctx.Checks.FirstOrDefault(f => f.CheckId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.Checks.FirstOrDefault(f => f.CheckId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
