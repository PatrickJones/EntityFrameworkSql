using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class PatientMedicationsRepo : BaseRepo<PatientMedications, NuMedicsGlobalContext>
    {
        public PatientMedicationsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {

        }

        public override PatientMedications GetSingle(int id)
        {
            try
            {
                return ctx.PatientMedications.FirstOrDefault(f => f.PatientMedicationId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(PatientMedications)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.PatientMedications.FirstOrDefault(f => f.PatientMedicationId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(PatientMedications)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
