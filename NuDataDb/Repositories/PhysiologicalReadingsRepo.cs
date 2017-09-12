using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PhysiologicalReadingsRepo : BaseRepo<PhysiologicalReadings, NuMedicsGlobalContext>
    {
        public PhysiologicalReadingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PhysiologicalReadings GetSingle(int id)
        {
            try
            {
                return ctx.PhysiologicalReadings.FirstOrDefault(f => f.ReadingId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(PhysiologicalReadings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.PhysiologicalReadings.FirstOrDefault(f => f.ReadingId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(PhysiologicalReadings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
