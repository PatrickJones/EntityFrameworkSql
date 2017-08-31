using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class BolusCarbsRepo : BaseRepo<BolusCarbs>
    {
        public BolusCarbsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override BolusCarbs GetSingle(int id)
        {
            try
            {
                return ctx.BolusCarbs.FirstOrDefault(f => f.CarbId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(BolusCarbs)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.BolusCarbs.FirstOrDefault(f => f.CarbId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(BolusCarbs)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
