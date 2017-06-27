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
            return ctx.InsulinBrands.FirstOrDefault(f => f.InsulinBrandId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.InsulinBrands.FirstOrDefault(f => f.InsulinBrandId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
