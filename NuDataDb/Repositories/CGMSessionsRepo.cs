using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class CGMSessionsRepo : BaseRepo<Cgmsessions, NuMedicsGlobalContext>
    {
        public CGMSessionsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Cgmsessions GetSingle(long id)
        {
            try
            {
                return ctx.Cgmsessions.FirstOrDefault(f => f.CgmsessionId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(Cgmsessions)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(long id)
        {
            try
            {
                var del = ctx.Cgmsessions.FirstOrDefault(f => f.CgmsessionId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(Cgmsessions)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
