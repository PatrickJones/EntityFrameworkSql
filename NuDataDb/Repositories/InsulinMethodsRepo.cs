using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class InsulinMethodsRepo : BaseRepo<InsulinMethods>
    {
        public InsulinMethodsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override InsulinMethods GetSingle(int id)
        {
            return ctx.InsulinMethods.FirstOrDefault(f => f.InsulinMethodId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.InsulinMethods.FirstOrDefault(f => f.InsulinMethodId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
