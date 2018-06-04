using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class PumpProgramTypesRepo : BaseRepo<PumpProgramTypes, NuMedicsGlobalContext>
    {
        public PumpProgramTypesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PumpProgramTypes GetSingle(int id)
        {
            try
            {
                return ctx.PumpProgramTypes.FirstOrDefault(f => f.TypeId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(PumpProgramTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.PumpProgramTypes.FirstOrDefault(f => f.TypeId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(PumpProgramTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
