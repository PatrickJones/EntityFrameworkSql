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
            try
            {
                return ctx.BasalDeliveries.FirstOrDefault(f => f.BasalDeliveryId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(Applications)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.BasalDeliveries.FirstOrDefault((f => f.BasalDeliveryId == id));
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(BasalDeliveries)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
