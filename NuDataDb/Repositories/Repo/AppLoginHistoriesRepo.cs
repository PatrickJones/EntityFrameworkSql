using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class AppLoginHistoriesRepo : BaseRepo<AppLoginHistories>
    {
        public AppLoginHistoriesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override AppLoginHistories GetSingle(int id)
        {
            return ctx.AppLoginHistories.FirstOrDefault(f => f.HistoryId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.AppLoginHistories.FirstOrDefault(f => f.HistoryId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
