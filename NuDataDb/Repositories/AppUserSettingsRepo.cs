using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class AppUserSettingsRepo : BaseRepo<AppUserSettings>
    {
        public AppUserSettingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override AppUserSettings GetSingle(int id)
        {
            return ctx.AppUserSettings.FirstOrDefault(f => f.AppUserSettingId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.AppUserSettings.FirstOrDefault(f => f.AppUserSettingId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
