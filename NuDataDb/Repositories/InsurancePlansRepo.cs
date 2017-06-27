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
            return ctx.InsurancePlans.FirstOrDefault(f => f.PlanId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.InsurancePlans.FirstOrDefault(f => f.PlanId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
