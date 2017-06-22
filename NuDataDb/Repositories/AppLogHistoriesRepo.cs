using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class AppLogHistoriesRepo : BaseRepo<AppLoginHistories>
    {
        public AppLogHistoriesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
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
