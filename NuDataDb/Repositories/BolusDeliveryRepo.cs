using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class BolusDeliveryRepo : BaseRepo<BolusDelivery>
    {
        public BolusDeliveryRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override BolusDelivery GetSingle(int id)
        {
            return ctx.BolusDelivery.FirstOrDefault(f => f.BolusDeliveryId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.BolusDelivery.FirstOrDefault(f => f.BolusDeliveryId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
