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
            try
            {
                return ctx.BasalProgramTimeSlots.FirstOrDefault(f => f.BasalSlotId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(BasalProgramTimeSlots)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.BasalProgramTimeSlots.FirstOrDefault(f => f.BasalSlotId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(BasalProgramTimeSlots)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
