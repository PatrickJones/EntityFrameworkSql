using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class BasalDeliveriesRepo : BaseRepo<BasalDeliveries>
    {
        public BasalDeliveriesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override BasalDeliveries GetSingle(int id)
        {
            return ctx.BasalDeliveries.FirstOrDefault(f => f.BasalDeliveryId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.BasalDeliveries.FirstOrDefault((f => f.BasalDeliveryId == id));
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
