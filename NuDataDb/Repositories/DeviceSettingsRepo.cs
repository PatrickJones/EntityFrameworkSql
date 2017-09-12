using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class DeviceSettingsRepo : BaseRepo<DeviceSettings, NuMedicsGlobalContext>
    {
        public DeviceSettingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override DeviceSettings GetSingle(int id)
        {
            try
            {
                return ctx.DeviceSettings.FirstOrDefault(f => f.SettingId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(DeviceSettings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.DeviceSettings.FirstOrDefault(f => f.SettingId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(DeviceSettings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
