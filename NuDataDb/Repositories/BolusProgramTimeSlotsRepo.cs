using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class BolusProgramTimeSlotsRepo : BaseRepo<BolusProgramTimeSlots>
    {
        public BolusProgramTimeSlotsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override BolusProgramTimeSlots GetSingle(int id)
        {
            return ctx.BolusProgramTimeSlots.FirstOrDefault(f => f.BolusSlotId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.BolusProgramTimeSlots.FirstOrDefault(f => f.BolusSlotId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
