using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class DailyTimeSlotsRepo : BaseRepo<DailyTimeSlots>
    {
        public DailyTimeSlotsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override DailyTimeSlots GetSingle(int id)
        {
            return ctx.DailyTimeSlots.FirstOrDefault(f => f.TimeSlotId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.DailyTimeSlots.FirstOrDefault(f => f.TimeSlotId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
