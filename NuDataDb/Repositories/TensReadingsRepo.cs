using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class TensReadingsRepo : BaseRepo<TensReadings>
    {
        public TensReadingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override TensReadings GetSingle(int id)
        {
            return ctx.TensReadings.FirstOrDefault(f => f.ReadingId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.TensReadings.FirstOrDefault(f => f.ReadingId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
