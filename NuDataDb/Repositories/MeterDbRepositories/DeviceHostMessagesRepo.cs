using NuDataDb.EFMetersDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.MeterDbRepositories
{
    public class DeviceHostMessagesRepo : BaseRepo<DeviceHostMessages, MeterDevicesDbContext>
    {
        public DeviceHostMessagesRepo(MeterDevicesDbContext dbContext) : base(dbContext)
        {
        }

        public override DeviceHostMessages GetSingle(int id)
        {
            try
            {
                return ctx.DeviceHostMessages.FirstOrDefault(f => f.MessageId == id);

            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(DeviceHostMessages)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.DeviceHostMessages.FirstOrDefault(f => f.MessageId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }

            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(DeviceHostMessages)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
