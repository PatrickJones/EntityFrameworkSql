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
            try
            {
                return ctx.BolusDeliveryData.FirstOrDefault(f => f.DataId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(BolusDeliveryData)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.BolusDeliveryData.FirstOrDefault(f => f.DataId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(BolusDeliveryData)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
