using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class ProgramTimeSlotsRepo : BaseRepo<ProgramTimeSlots, NuMedicsGlobalContext>
    {
        public ProgramTimeSlotsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override ProgramTimeSlots GetSingle(int id)
        {
            try
            {
                return ctx.BasalProgramTimeSlots.FirstOrDefault(f => f.SlotId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(ProgramTimeSlots)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.BasalProgramTimeSlots.FirstOrDefault(f => f.SlotId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(ProgramTimeSlots)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
