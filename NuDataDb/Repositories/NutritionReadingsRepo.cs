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
            return ctx.NutritionReadings.FirstOrDefault(f => f.ReadingId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.NutritionReadings.FirstOrDefault(f => f.ReadingId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
