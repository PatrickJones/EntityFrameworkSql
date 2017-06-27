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
            return ctx.PatientPhoneNumbers.FirstOrDefault(f => f.PhoneId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.PatientPhoneNumbers.FirstOrDefault(f => f.PhoneId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
