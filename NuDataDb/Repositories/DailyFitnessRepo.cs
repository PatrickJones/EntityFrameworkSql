using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class DailyFitnessRepo : BaseRepo<DailyFitness, NuMedicsGlobalContext>
    {
        public DailyFitnessRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override DailyFitness GetSingle(int id)
        {
            try
            {
                return ctx.DailyFitness.FirstOrDefault(f => f.DailyFitnessId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(DailyFitness)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.DailyFitness.FirstOrDefault(f => f.DailyFitnessId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(DailyFitness)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
