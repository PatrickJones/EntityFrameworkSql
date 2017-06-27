using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class BolusCarbsRepo : BaseRepo<BolusCarbs>
    {
        public BolusCarbsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override BolusCarbs GetSingle(int id)
        {
            return ctx.BolusCarbs.FirstOrDefault(f => f.CarbId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.BolusCarbs.FirstOrDefault(f => f.CarbId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
