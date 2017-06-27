using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PatientsInsurancePlansRepo : BaseRepo<PatientsInsurancePlans>
    {
        public PatientsInsurancePlansRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PatientsInsurancePlans GetSingle(Guid id)
        {
            return ctx.PatientsInsurancePlans.FirstOrDefault(f => f.UserId == id);
        }

        public override void Delete(Guid id)
        {
            var del = ctx.PatientsInsurancePlans.FirstOrDefault(f => f.UserId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
