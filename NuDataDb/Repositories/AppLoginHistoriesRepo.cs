using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class AppLoginHistoriesRepo : BaseRepo<AppLoginHistories, NuMedicsGlobalContext>
    {
        public AppLoginHistoriesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override AppLoginHistories GetSingle(int id)
        {
            try
            {
                return ctx.AppLoginHistories.FirstOrDefault(f => f.HistoryId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(AppLoginHistories)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.AppLoginHistories.FirstOrDefault(f => f.HistoryId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }

            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(AppLoginHistories)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
