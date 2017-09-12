using NuDataDb.EFMetersDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.MeterDbRepositories
{
    public class DeviceHostRepo : BaseRepo<DeviceHost,MeterDevicesDbContext>
    {
        protected DeviceHostRepo(MeterDevicesDbContext dbContext) : base(dbContext)
        {
        }

        public override DeviceHost GetSingle(Guid id)
        {
            try
            {
                return ctx.DeviceHost.FirstOrDefault(f => f.DeviceHostId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(DeviceHost)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(Guid id)
        {
            try
            {
                var del = ctx.DeviceHost.FirstOrDefault(f => f.DeviceHostId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(DeviceHost)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
