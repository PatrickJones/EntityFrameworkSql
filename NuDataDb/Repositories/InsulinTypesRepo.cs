using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class InsulinTypesRepo : BaseRepo<InsulinTypes>
    {
        public InsulinTypesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override InsulinTypes GetSingle(int id)
        {
            return ctx.InsulinTypes.FirstOrDefault(f => f.InsulinTypeId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.InsulinTypes.FirstOrDefault(f => f.InsulinTypeId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
