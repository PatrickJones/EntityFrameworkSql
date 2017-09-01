using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class NutritionReadingsRepo : BaseRepo<NutritionReadings>
    {
        public NutritionReadingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override NutritionReadings GetSingle(int id)
        {
            try
            {
                return ctx.NutritionReadings.FirstOrDefault(f => f.ReadingId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(NutritionReadings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.NutritionReadings.FirstOrDefault(f => f.ReadingId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(NutritionReadings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
