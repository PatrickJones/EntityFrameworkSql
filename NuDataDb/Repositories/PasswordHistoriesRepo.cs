using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class PasswordHistoriesRepo : BaseRepo<PasswordHistories>
    {
        public PasswordHistoriesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PasswordHistories GetSingle(int id)
        {
            try
            {
                return ctx.PasswordHistories.FirstOrDefault(f => f.HistoryId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(PasswordHistories)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.PasswordHistories.FirstOrDefault(f => f.HistoryId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(PasswordHistories)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
