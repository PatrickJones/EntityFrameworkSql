using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class BolusDeliveryDataRepo : BaseRepo<BolusDeliveryData>
    {
        public BolusDeliveryDataRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override BolusDeliveryData GetSingle(int id)
        {
            return ctx.BolusDeliveryData.FirstOrDefault(f => f.DataId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.BolusDeliveryData.FirstOrDefault(f => f.DataId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
