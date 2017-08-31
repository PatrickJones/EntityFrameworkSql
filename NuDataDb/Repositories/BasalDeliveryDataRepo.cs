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
            try
            {
                return ctx.BasalDeliveryData.FirstOrDefault(f => f.DataId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(BasalDeliveryData)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.BasalDeliveryData.FirstOrDefault(f => f.DataId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(BasalDeliveryData)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
