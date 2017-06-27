using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PumpsRepo : BaseRepo<Pumps>
    {
        public PumpsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Pumps GetSingle(Guid id)
        {
            return ctx.Pumps.FirstOrDefault(f => f.PumpKeyId == id);
        }

        public override void Delete(Guid id)
        {
            var del = ctx.Pumps.FirstOrDefault(f => f.PumpKeyId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
