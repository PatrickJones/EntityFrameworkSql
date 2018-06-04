using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class ChecksRepo : BaseRepo<Checks, NuMedicsGlobalContext>
    {
        public ChecksRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Checks GetSingle(int id)
        {
            try
            {
                return ctx.Checks.FirstOrDefault(f => f.CheckId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(Checks)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.Checks.FirstOrDefault(f => f.CheckId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(Checks)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
