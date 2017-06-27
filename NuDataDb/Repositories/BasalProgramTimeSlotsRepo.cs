using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class BasalProgramTimeSlotsRepo : BaseRepo<BasalProgramTimeSlots>
    {
        public BasalProgramTimeSlotsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override BasalProgramTimeSlots GetSingle(int id)
        {
            return ctx.BasalProgramTimeSlots.FirstOrDefault(f => f.BasalSlotId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.BasalProgramTimeSlots.FirstOrDefault(f => f.BasalSlotId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
