using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PatientsInsurancePlansRepo : BaseRepo<PatientsInsurancePlans, NuMedicsGlobalContext>
    {
        public PatientsInsurancePlansRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PatientsInsurancePlans GetSingle(Guid id)
        {
            try
            {
                return ctx.PatientsInsurancePlans.FirstOrDefault(f => f.UserId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(PatientsInsurancePlans)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(Guid id)
        {
            try
            {
                var del = ctx.PatientsInsurancePlans.FirstOrDefault(f => f.UserId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(PatientsInsurancePlans)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
