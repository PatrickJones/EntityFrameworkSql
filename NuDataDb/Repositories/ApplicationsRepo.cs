using NuDataDb.AppInterfaces;
using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class ApplicationsRepo : BaseRepo<Applications, NuMedicsGlobalContext>
    {
        public ApplicationsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Applications GetSingle(Guid id)
        {
            try
            {
                return ctx.Applications.FirstOrDefault(f => f.ApplicationId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(Applications)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(Guid id)
        {
            try
            {
                var del = ctx.Applications.FirstOrDefault(f => f.ApplicationId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(Applications)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
