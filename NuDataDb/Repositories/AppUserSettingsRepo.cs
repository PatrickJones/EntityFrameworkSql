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
            try
            {
                return ctx.AppUserSettings.FirstOrDefault(f => f.AppUserSettingId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(AppUserSettings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.AppUserSettings.FirstOrDefault(f => f.AppUserSettingId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(AppUserSettings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
