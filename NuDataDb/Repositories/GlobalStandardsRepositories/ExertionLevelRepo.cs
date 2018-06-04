using NuDataDb.EFGlobalStandards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.GlobalStandardsRepositories
{
    public class ExertionLevelRepo : BaseRepo<ExertionLevels, GlobalStandardsContext>
    {
        public ExertionLevelRepo(GlobalStandardsContext dbContext) : base(dbContext)
        {
        }

        public override ExertionLevels GetSingle(int id)
        {
            try
            {
                return ctx.ExertionLevels.FirstOrDefault(f => f.ExertionId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(ExertionLevels)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.ExertionLevels.FirstOrDefault(f => f.ExertionId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(ExertionLevels)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
