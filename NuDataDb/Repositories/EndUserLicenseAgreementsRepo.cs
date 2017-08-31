using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class EndUserLicenseAgreementsRepo : BaseRepo<EndUserLicenseAgreements>
    {
        public EndUserLicenseAgreementsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override EndUserLicenseAgreements GetSingle(int id)
        {
            try
            {
                return ctx.EndUserLicenseAgreements.FirstOrDefault(f => f.AgreementId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(EndUserLicenseAgreements)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.EndUserLicenseAgreements.FirstOrDefault(f => f.AgreementId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(EndUserLicenseAgreements)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
