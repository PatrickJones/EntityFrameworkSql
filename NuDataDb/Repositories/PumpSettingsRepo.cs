using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PumpSettingsRepo : BaseRepo<PumpSettings, NuMedicsGlobalContext>
    {
        public PumpSettingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PumpSettings GetSingle(int id)
        {
            try
            {
                return ctx.PumpSettings.FirstOrDefault(f => f.SettingId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(PumpSettings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.PumpSettings.FirstOrDefault(f => f.SettingId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(PumpSettings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
