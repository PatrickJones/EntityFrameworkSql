using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class DiabetesManagementTypesRepo : BaseRepo<DiabetesManagementTypes>
    {
        public DiabetesManagementTypesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override DiabetesManagementTypes GetSingle(int id)
        {
            return ctx.DiabetesManagementTypes.FirstOrDefault(f => f.TypeId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.DiabetesManagementTypes.FirstOrDefault(f => f.TypeId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
