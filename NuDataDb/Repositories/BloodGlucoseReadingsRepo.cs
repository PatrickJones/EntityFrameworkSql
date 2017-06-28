using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class BloodGlucoseReadingsRepo : BaseRepo<BloodGlucoseReadings>
    {
        public BloodGlucoseReadingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override BloodGlucoseReadings GetSingle(Int64 id)
        {
            return ctx.BloodGlucoseReadings.FirstOrDefault(f => f.ReadingId == id);
        }

        public override BloodGlucoseReadings GetSingle(int id)
        {
            return ctx.BloodGlucoseReadings.FirstOrDefault(f => f.ReadingId == id);
        }

        public override void Delete(Int64 id)
        {
            var del = ctx.BloodGlucoseReadings.FirstOrDefault(f => f.ReadingId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }

        public override void Delete(int id)
        {
            var del = ctx.BloodGlucoseReadings.FirstOrDefault(f => f.ReadingId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
