using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class InsulinCarbRatioRepo : BaseRepo<InsulinCarbRatio>
    {
        public InsulinCarbRatioRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override InsulinCarbRatio GetSingle(int id)
        {
            return ctx.InsulinCarbRatio.FirstOrDefault(f => f.RatioId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.InsulinCarbRatio.FirstOrDefault(f => f.RatioId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
