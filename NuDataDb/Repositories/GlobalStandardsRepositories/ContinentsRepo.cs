using NuDataDb.EFGlobalStandards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.GlobalStandardsRepositories
{
    public class ContinentsRepo : BaseRepo<Continents, GlobalStandardsContext>
    {
        public ContinentsRepo(GlobalStandardsContext dbContext) : base(dbContext)
        {
        }

        public override Continents GetSingle(int id)
        {
            try
            {
                return ctx.Continents.FirstOrDefault(f => f.ContinentId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(Continents)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.Continents.FirstOrDefault(f => f.ContinentId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(Continents)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

    }
}
