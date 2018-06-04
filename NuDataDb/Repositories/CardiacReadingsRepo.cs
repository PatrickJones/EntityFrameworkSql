using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class CardiacReadingsRepo : BaseRepo<CardiacReadings, NuMedicsGlobalContext>
    {
        public CardiacReadingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override CardiacReadings GetSingle(int id)
        {
            try
            {
                return ctx.CardiacReadings.FirstOrDefault(f => f.CardiacReadingId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(CardiacReadings)} entity from database. /n/r Entity Id: {id}", e); ;
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.CardiacReadings.FirstOrDefault(f => f.CardiacReadingId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(CardiacReadings)} entity from database. /n/r Entity Id: {id}", e); ;
            }
        }
    }
}
