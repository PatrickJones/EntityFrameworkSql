using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class NuMedicsUserPrintSettingsRepo : BaseRepo<NuMedicsUserPrintSettings, NuMedicsGlobalContext>
    {
        public NuMedicsUserPrintSettingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override NuMedicsUserPrintSettings GetSingle(int id)
        {
            try
            {
                return ctx.NuMedicsUserPrintSettings.FirstOrDefault(f => f.PrintSettingId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(NuMedicsUserPrintSettings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.NuMedicsUserPrintSettings.FirstOrDefault(f => f.PrintSettingId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(NuMedicsUserPrintSettings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
