using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PumpsRepo : BaseRepo<Pumps, NuMedicsGlobalContext>
    {
        public PumpsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Pumps GetSingle(Guid id)
        {
            try
            {
                return ctx.Pumps.FirstOrDefault(f => f.PumpKeyId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(Pumps)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(Guid id)
        {
            try
            {
                var del = ctx.Pumps.FirstOrDefault(f => f.PumpKeyId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(Pumps)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
