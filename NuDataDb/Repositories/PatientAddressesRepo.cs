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
            try
            {
                return ctx.PatientAddresses.FirstOrDefault(f => f.AddressId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(PatientAddresses)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.PatientAddresses.FirstOrDefault(f => f.AddressId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(PatientAddresses)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
