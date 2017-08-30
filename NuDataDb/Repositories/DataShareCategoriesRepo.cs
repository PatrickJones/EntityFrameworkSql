using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class DataShareCategoriesRepo : BaseRepo<DataShareCategories>
    {
        public DataShareCategoriesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override DataShareCategories GetSingle(int id)
        {
            return ctx.DataShareCategories.FirstOrDefault(f => f.CategoryId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.DataShareCategories.FirstOrDefault(f => f.CategoryId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
