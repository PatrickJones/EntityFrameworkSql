using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class SharedAreasRepo : BaseRepo<SharedAreas, NuMedicsGlobalContext>
    {
        public SharedAreasRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override SharedAreas GetSingle(int id)
        {
            try
            {
                return ctx.SharedAreas.FirstOrDefault(f => f.DataShareCategoryId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(SharedAreas)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.SharedAreas.FirstOrDefault(f => f.DataShareCategoryId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(SharedAreas)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
