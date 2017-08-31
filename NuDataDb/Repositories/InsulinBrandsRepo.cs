using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class InsulinBrandsRepo : BaseRepo<InsulinBrands>
    {
        public InsulinBrandsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override InsulinBrands GetSingle(int id)
        {
            try
            {
                return ctx.InsulinBrands.FirstOrDefault(f => f.InsulinBrandId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(InsulinBrands)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.InsulinBrands.FirstOrDefault(f => f.InsulinBrandId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(InsulinBrands)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
