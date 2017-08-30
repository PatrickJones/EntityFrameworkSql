using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class SharedAreasRepo : BaseRepo<SharedAreas>
    {
        public SharedAreasRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override SharedAreas GetSingle(int id)
        {
            return ctx.SharedAreas.FirstOrDefault(f => f.DataShareCategoryId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.SharedAreas.FirstOrDefault(f => f.DataShareCategoryId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
