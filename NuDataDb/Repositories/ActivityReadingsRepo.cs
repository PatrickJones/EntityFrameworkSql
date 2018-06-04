using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class ActivityReadingsRepo : BaseRepo<ActivityReadings, NuMedicsGlobalContext>
    {
        public ActivityReadingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override ActivityReadings GetSingle(int id)
        {
            try
            {
                return ctx.ActivityReadings.FirstOrDefault(f => f.ActivityReadingId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(ActivityReadings)} entity from database. /n/r Entity Id: {id}", e); ;
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.ActivityReadings.FirstOrDefault(f => f.ActivityReadingId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(ActivityReadings)} entity from database. /n/r Entity Id: {id}", e); ;
            }
        }
    }
}
