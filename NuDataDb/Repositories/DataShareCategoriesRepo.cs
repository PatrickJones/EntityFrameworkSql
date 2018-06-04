using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class DataShareCategoriesRepo : BaseRepo<DataShareCategories, NuMedicsGlobalContext>
    {
        public DataShareCategoriesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override DataShareCategories GetSingle(int id)
        {
            try
            {
                return ctx.DataShareCategories.FirstOrDefault(f => f.CategoryId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(DataShareCategories)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.DataShareCategories.FirstOrDefault(f => f.CategoryId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(DataShareCategories)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
