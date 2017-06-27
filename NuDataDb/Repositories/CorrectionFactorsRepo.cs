using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class CorrectionFactorsRepo : BaseRepo<CorrectionFactors>
    {
        public CorrectionFactorsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override CorrectionFactors GetSingle(int id)
        {
            return ctx.CorrectionFactors.FirstOrDefault(f => f.FactorId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.CorrectionFactors.FirstOrDefault(f => f.FactorId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
