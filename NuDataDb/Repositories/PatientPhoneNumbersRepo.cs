using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PatientPhoneNumbersRepo : BaseRepo<PatientPhoneNumbers>
    {
        public PatientPhoneNumbersRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PatientPhoneNumbers GetSingle(int id)
        {
            try
            {
                return ctx.PatientPhoneNumbers.FirstOrDefault(f => f.PhoneId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(PatientPhoneNumbers)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.PatientPhoneNumbers.FirstOrDefault(f => f.PhoneId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(PatientPhoneNumbers)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
