using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class InsulinMethodsRepo : BaseRepo<InsulinMethods>
    {
        public InsulinMethodsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override InsulinMethods GetSingle(int id)
        {
            try
            {
                return ctx.InsulinMethods.FirstOrDefault(f => f.InsulinMethodId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(InsulinMethods)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.InsulinMethods.FirstOrDefault(f => f.InsulinMethodId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }

            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(InsulinMethods)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
