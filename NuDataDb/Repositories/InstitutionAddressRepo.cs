using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class InstitutionAddressRepo : BaseRepo<InstitutionAddresses, NuMedicsGlobalContext>
    {
        public InstitutionAddressRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override InstitutionAddresses GetSingle(int id)
        {
            try
            {
                return ctx.InstitutionAddresses.FirstOrDefault(f => f.AddressId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(InstitutionAddresses)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.InstitutionAddresses.FirstOrDefault(f => f.AddressId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(InstitutionAddresses)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
