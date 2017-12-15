using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PatientInsuranceRepo : BaseRepo<PatientInsurance, NuMedicsGlobalContext>
    {
        public PatientInsuranceRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PatientInsurance GetSingle(int id)
        {
            try
            {
                return ctx.PatientInsurance.FirstOrDefault(f => f.PatientInsuranceId == id);
            }
            catch (Exception e)
            {
                throw;throw new Exception($"Error getting {typeof(PatientInsurance)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.PatientInsurance.FirstOrDefault(f => f.PatientInsuranceId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw;throw new Exception($"Error deleting {typeof(PatientInsurance)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
