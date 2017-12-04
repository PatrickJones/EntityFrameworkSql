using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class CareTargetsRepo : BaseRepo<CareSettings, NuMedicsGlobalContext>
    {
        public CareTargetsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
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
                throw new Exception($"Error getting {typeof(CareSettings)} entity from database. /n/r Entity Id: {id}", e); ;
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
                throw new Exception($"Error deleting {typeof(CareSettings)} entity from database. /n/r Entity Id: {id}", e); ;
            }
        }
    }
}
