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
            try
            {
                return ctx.BolusProgramTimeSlots.FirstOrDefault(f => f.BolusSlotId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(BolusProgramTimeSlots)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.BolusProgramTimeSlots.FirstOrDefault(f => f.BolusSlotId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(BolusProgramTimeSlots)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
