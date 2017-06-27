using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class DeviceSettingsRepo : BaseRepo<DeviceSettings>
    {
        public DeviceSettingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override DeviceSettings GetSingle(int id)
        {
            return ctx.DeviceSettings.FirstOrDefault(f => f.SettingId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.DeviceSettings.FirstOrDefault(f => f.SettingId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
