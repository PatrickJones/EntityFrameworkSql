using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class BolusDeliveriesRepo : BaseRepo<BolusDeliveries>
    {
        public BolusDeliveriesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override BolusDeliveries GetSingle(int id)
        {
            return ctx.BolusDeliveries.FirstOrDefault(f => f.BolusDeliveryId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.BolusDeliveries.FirstOrDefault(f => f.BolusDeliveryId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
