using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PumpSettingsRepo : BaseRepo<PumpSettings>
    {
        public PumpSettingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PumpSettings GetSingle(int id)
        {
            return ctx.PumpSettings.FirstOrDefault(f => f.SettingId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.PumpSettings.FirstOrDefault(f => f.SettingId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
