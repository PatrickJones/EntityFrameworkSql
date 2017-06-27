using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class CheckStatusRepo : BaseRepo<CheckStatus>
    {
        public CheckStatusRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override CheckStatus GetSingle(int id)
        {
            return ctx.CheckStatus.FirstOrDefault(f => f.StatusId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.CheckStatus.FirstOrDefault(f => f.StatusId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
