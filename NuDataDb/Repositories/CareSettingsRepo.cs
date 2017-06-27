using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class CareSettingsRepo : BaseRepo<CareSettings>
    {
        public CareSettingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override CareSettings GetSingle(int id)
        {
            return ctx.CareSettings.FirstOrDefault(f => f.CareSettingsId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.CareSettings.FirstOrDefault(f => f.CareSettingsId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
