using NuDataDb.EFGlobalStandards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.GlobalStandardsRepositories
{
    public class StatesRepo : BaseRepo<States, GlobalStandardsContext>
    {
        public StatesRepo(GlobalStandardsContext dbContext) : base(dbContext)
        {
        }

        public override States GetSingle(int id)
        {
            try
            {
                return ctx.States.FirstOrDefault(f => f.StateId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(States)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.States.FirstOrDefault(f => f.StateId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(States)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

    }
}
