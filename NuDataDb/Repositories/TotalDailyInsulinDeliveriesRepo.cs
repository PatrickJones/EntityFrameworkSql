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
            try
            {
                return ctx.TotalDailyInsulinDeliveries.FirstOrDefault(f => f.DeliveryId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(TotalDailyInsulinDeliveries)} entity from database. /n/r Entity Id: {id}", e);;
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.TotalDailyInsulinDeliveries.FirstOrDefault(f => f.DeliveryId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(TotalDailyInsulinDeliveries)} entity from database. /n/r Entity Id: {id}", e);;
            }
        }
    }
}
