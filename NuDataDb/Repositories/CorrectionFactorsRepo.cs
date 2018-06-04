using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class CorrectionFactorsRepo : BaseRepo<CorrectionFactors, NuMedicsGlobalContext>
    {
        public CorrectionFactorsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override CorrectionFactors GetSingle(int id)
        {
            try
            {
                return ctx.CorrectionFactors.FirstOrDefault(f => f.FactorId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(CorrectionFactors)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.CorrectionFactors.FirstOrDefault(f => f.FactorId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(CorrectionFactors)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
