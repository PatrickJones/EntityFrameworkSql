using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class AppSettingsRepo : BaseRepo<AppSettings>
    {
        public AppSettingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override AppSettings GetSingle(int id)
        {
            try
            {
                return ctx.AppSettings.FirstOrDefault(f => f.AppSettingId == id);

            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(AppSettings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.AppSettings.FirstOrDefault(f => f.AppSettingId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }

            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(AppSettings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

    }
}
