using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class InsuranceProvidersRepo : BaseRepo<InsuranceProviders, NuMedicsGlobalContext>
    {
        public InsuranceProvidersRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override InsuranceProviders GetSingle(int id)
        {
            try
            {
                return ctx.InsuranceProviders.FirstOrDefault(f => f.CompanyId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(InsuranceProviders)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.InsuranceProviders.FirstOrDefault(f => f.CompanyId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(InsuranceProviders)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
