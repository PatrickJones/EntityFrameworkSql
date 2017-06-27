using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class TherapyTypesRepo : BaseRepo<TherapyTypes>
    {
        public TherapyTypesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override TherapyTypes GetSingle(int id)
        {
            return ctx.TherapyTypes.FirstOrDefault(f => f.TypeId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.TherapyTypes.FirstOrDefault(f => f.TypeId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
