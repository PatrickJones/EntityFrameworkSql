using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class InsuranceAddressesRepo : BaseRepo<InsuranceAddresses, NuMedicsGlobalContext>
    {
        public InsuranceAddressesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override InsuranceAddresses GetSingle(int id)
        {
            try
            {
                return ctx.InsuranceAddresses.FirstOrDefault(f => f.AddressId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(InsuranceAddresses)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.InsuranceAddresses.FirstOrDefault(f => f.AddressId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(InsuranceAddresses)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
