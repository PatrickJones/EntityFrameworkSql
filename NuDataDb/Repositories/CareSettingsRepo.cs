using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class CareSettingsRepo : BaseRepo<CareSettings, NuMedicsGlobalContext>
    {
        public CareSettingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override CareSettings GetSingle(int id)
        {
            try
            {
                return ctx.CareSettings.FirstOrDefault(f => f.CareSettingsId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(CareSettings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.CareSettings.FirstOrDefault(f => f.CareSettingsId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(CareSettings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
