using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class SleepReadingsRepo : BaseRepo<SleepReadings, NuMedicsGlobalContext>
    {
        public SleepReadingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override SleepReadings GetSingle(int id)
        {
            try
            {
                return ctx.SleepReadings.FirstOrDefault(f => f.SleepReadingId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(SleepReadings)} entity from database. /n/r Entity Id: {id}", e); ;
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.SleepReadings.FirstOrDefault(f => f.SleepReadingId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(SleepReadings)} entity from database. /n/r Entity Id: {id}", e); ;
            }
        }
    }
}
