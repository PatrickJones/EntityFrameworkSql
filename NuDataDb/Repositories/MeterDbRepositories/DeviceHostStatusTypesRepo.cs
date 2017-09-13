using NuDataDb.EFMetersDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.MeterDbRepositories
{
    public class DeviceHostStatusTypesRepo : BaseRepo<DeviceHostStatusTypes, MeterDevicesDbContext>
    {
        public DeviceHostStatusTypesRepo(MeterDevicesDbContext dbContext) : base(dbContext)
        {
        }

        public override DeviceHostStatusTypes GetSingle(int id)
        {
            try
            {
                return ctx.DeviceHostStatusTypes.FirstOrDefault(f => f.StatusId == id);

            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(DeviceHostStatusTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.DeviceHostStatusTypes.FirstOrDefault(f => f.StatusId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(DeviceHostStatusTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
