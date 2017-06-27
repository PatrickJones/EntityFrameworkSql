using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class DiabetesControlTypesRepo : BaseRepo<DiabetesControlTypes>
    {
        public DiabetesControlTypesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override DiabetesControlTypes GetSingle(int id)
        {
            return ctx.DiabetesControlTypes.FirstOrDefault(f => f.TypeId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.DiabetesControlTypes.FirstOrDefault(f => f.TypeId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
