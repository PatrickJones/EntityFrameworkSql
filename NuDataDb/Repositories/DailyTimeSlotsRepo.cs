using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class DailyTimeSlotsRepo : BaseRepo<DailyTimeSlots, NuMedicsGlobalContext>
    {
        public DailyTimeSlotsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override DailyTimeSlots GetSingle(int id)
        {
            try
            {
                return ctx.DailyTimeSlots.FirstOrDefault(f => f.TimeSlotId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(DailyTimeSlots)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.DailyTimeSlots.FirstOrDefault(f => f.TimeSlotId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(DailyTimeSlots)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
