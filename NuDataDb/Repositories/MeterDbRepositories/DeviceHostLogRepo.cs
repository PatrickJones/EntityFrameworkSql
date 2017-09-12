using NuDataDb.EFMetersDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.MeterDbRepositories
{
    public class DeviceHostLogRepo : BaseRepo<DeviceHostLog, MeterDevicesDbContext>
    {
        public DeviceHostLogRepo(MeterDevicesDbContext dbContext) : base(dbContext)
        {
        }

        public override DeviceHostLog GetSingle(int id)
        {
            try
            {
                return ctx.DeviceHostLog.FirstOrDefault(f => f.LogId == id);

            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(DeviceHostLog)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.DeviceHostLog.FirstOrDefault(f => f.LogId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }

            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(DeviceHostLog)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
