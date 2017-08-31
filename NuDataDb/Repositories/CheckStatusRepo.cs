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
            try
            {
                return ctx.CheckStatus.FirstOrDefault(f => f.StatusId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(CheckStatus)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.CheckStatus.FirstOrDefault(f => f.StatusId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(CheckStatus)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
