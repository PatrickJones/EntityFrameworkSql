using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class InsulinCarbRatioRepo : BaseRepo<InsulinCarbRatio, NuMedicsGlobalContext>
    {
        public InsulinCarbRatioRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override InsulinCarbRatio GetSingle(int id)
        {
            try
            {
                return ctx.InsulinCarbRatio.FirstOrDefault(f => f.RatioId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(InsulinCarbRatio)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.InsulinCarbRatio.FirstOrDefault(f => f.RatioId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(InsulinCarbRatio)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
