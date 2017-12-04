using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class ActivityTypesRepo : BaseRepo<ActivityTypes, NuMedicsGlobalContext>
    {
        public ActivityTypesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override ActivityTypes GetSingle(int id)
        {
            try
            {
                return ctx.ActivityTypes.FirstOrDefault(f => f.ActivityId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(ActivityTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.ActivityTypes.FirstOrDefault(f => f.ActivityId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(ActivityTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
