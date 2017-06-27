using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class InsuranceProvidersRepo : BaseRepo<InsuranceProviders>
    {
        public InsuranceProvidersRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override InsuranceProviders GetSingle(int id)
        {
            return ctx.InsuranceProviders.FirstOrDefault(f => f.CompanyId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.InsuranceProviders.FirstOrDefault(f => f.CompanyId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
