using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class InsuranceAddressesRepo : BaseRepo<InsuranceAddresses>
    {
        public InsuranceAddressesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override InsuranceAddresses GetSingle(int id)
        {
            return ctx.InsuranceAddresses.FirstOrDefault(f => f.AddressId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.InsuranceAddresses.FirstOrDefault(f => f.AddressId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
