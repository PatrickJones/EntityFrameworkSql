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
            return ctx.EndUserLicenseAgreements.FirstOrDefault(f => f.AgreementId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.EndUserLicenseAgreements.FirstOrDefault(f => f.AgreementId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
