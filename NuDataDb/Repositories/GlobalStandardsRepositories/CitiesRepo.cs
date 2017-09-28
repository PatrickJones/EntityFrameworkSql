using NuDataDb.EFGlobalStandards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.GlobalStandardsRepositories
{
    public class CitiesRepo : BaseRepo<Cities, GlobalStandardsContext>
    {
        public CitiesRepo(GlobalStandardsContext dbContext) : base(dbContext)
        {
        }

        public override Cities GetSingle(int id)
        {
            try
            {
                return ctx.Cities.FirstOrDefault(f => f.CityId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(Cities)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.Cities.FirstOrDefault(f => f.CityId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(Cities)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
