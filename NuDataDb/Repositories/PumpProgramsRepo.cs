using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PumpProgramsRepo : BaseRepo<PumpPrograms, NuMedicsGlobalContext>
    {
        public PumpProgramsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PumpPrograms GetSingle(int id)
        {
            try
            {
                return ctx.PumpPrograms.FirstOrDefault(f => f.PumpProgramId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(PumpPrograms)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.PumpPrograms.FirstOrDefault(f => f.PumpProgramId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(PumpPrograms)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
