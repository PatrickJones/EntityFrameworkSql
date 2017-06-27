using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PhysiologicalReadingsRepo : BaseRepo<PhysiologicalReadings>
    {
        public PhysiologicalReadingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PhysiologicalReadings GetSingle(int id)
        {
            return ctx.PhysiologicalReadings.FirstOrDefault(f => f.ReadingId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.PhysiologicalReadings.FirstOrDefault(f => f.ReadingId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
