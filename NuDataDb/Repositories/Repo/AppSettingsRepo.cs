using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class AppSettingsRepo : BaseRepo<AppSettings>
    {
        public AppSettingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override AppSettings GetSingle(int id)
        {
            return ctx.AppSettings.FirstOrDefault(f => f.AppSettingId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.AppSettings.FirstOrDefault(f => f.AppSettingId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
