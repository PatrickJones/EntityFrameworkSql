using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class DeviceDataRepo : BaseRepo<DeviceData, NuMedicsGlobalContext>
    {
        public DeviceDataRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override DeviceData GetSingle(int id)
        {
            try
            {
                return ctx.DeviceData.FirstOrDefault(f => f.DataSetId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(DeviceData)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.DeviceData.FirstOrDefault(f => f.DataSetId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }

            }
            catch (Exception e)
            {

                throw new Exception($"Error deleting {typeof(DeviceData)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
