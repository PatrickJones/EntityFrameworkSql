using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class BasalDeliveryDataRepo : BaseRepo<BasalDeliveryData>
    {
        public BasalDeliveryDataRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override BasalDeliveryData GetSingle(int id)
        {
            return ctx.BasalDeliveryData.FirstOrDefault(f => f.DataId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.BasalDeliveryData.FirstOrDefault(f => f.DataId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
