using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class DiabetesManagementDataRepo : BaseRepo<DiabetesManagementData>
    {
        public DiabetesManagementDataRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override DiabetesManagementData GetSingle(int id)
        {
            return ctx.DiabetesManagementData.FirstOrDefault(f => f.DmdataId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.DiabetesManagementData.FirstOrDefault(f => f.DmdataId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
