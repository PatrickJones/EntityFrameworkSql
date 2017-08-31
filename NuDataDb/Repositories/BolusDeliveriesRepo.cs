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
            try
            {
                return ctx.BolusDeliveries.FirstOrDefault(f => f.BolusDeliveryId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(BolusDeliveries)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.BolusDeliveries.FirstOrDefault(f => f.BolusDeliveryId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }

            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(BolusDeliveries)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
