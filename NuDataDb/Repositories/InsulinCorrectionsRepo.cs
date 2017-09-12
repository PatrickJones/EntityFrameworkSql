using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class InsulinCorrectionsRepo : BaseRepo<InsulinCorrections, NuMedicsGlobalContext>
    {
        public InsulinCorrectionsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override InsulinCorrections GetSingle(int id)
        {
            try
            {
                return ctx.InsulinCorrections.FirstOrDefault(f => f.CorrectionId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(InsulinCorrections)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.InsulinCorrections.FirstOrDefault(f => f.CorrectionId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(InsulinCorrections)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
