using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PatientAddressesRepo : BaseRepo<PatientAddresses>
    {
        public PatientAddressesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PatientAddresses GetSingle(int id)
        {
            return ctx.PatientAddresses.FirstOrDefault(f => f.AddressId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.PatientAddresses.FirstOrDefault(f => f.AddressId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
