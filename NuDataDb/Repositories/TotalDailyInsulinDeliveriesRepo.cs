using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class TotalDailyInsulinDeliveriesRepo : BaseRepo<TotalDailyInsulinDeliveries>
    {
        public TotalDailyInsulinDeliveriesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override TotalDailyInsulinDeliveries GetSingle(int id)
        {
            return ctx.TotalDailyInsulinDeliveries.FirstOrDefault(f => f.DeliveryId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.TotalDailyInsulinDeliveries.FirstOrDefault(f => f.DeliveryId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
