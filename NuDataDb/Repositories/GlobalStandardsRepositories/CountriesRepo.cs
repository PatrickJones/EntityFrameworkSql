using NuDataDb.EFGlobalStandards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.GlobalStandardsRepositories
{
    public class CountriesRepo : BaseRepo<Countries, GlobalStandardsContext>
    {
        public CountriesRepo(GlobalStandardsContext dbContext) : base(dbContext)
        {
        }

        public override Countries GetSingle(int id)
        {
            try
            {
                return ctx.Countries.FirstOrDefault(f => f.CountryId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(Countries)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.Countries.FirstOrDefault(f => f.CountryId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(Countries)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

    }
}
