using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class InsurancePlansRepo : BaseRepo<InsurancePlans>
    {
        public InsurancePlansRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override InsurancePlans GetSingle(int id)
        {
            try
            {
                return ctx.InsurancePlans.FirstOrDefault(f => f.PlanId == id);
            }
            catch (Exception e)
            {
                throw;throw new Exception($"Error getting {typeof(InsurancePlans)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.InsurancePlans.FirstOrDefault(f => f.PlanId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw;throw new Exception($"Error deleting {typeof(InsurancePlans)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
