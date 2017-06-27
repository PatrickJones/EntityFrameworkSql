using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class BGTargetsRepo : BaseRepo<Bgtargets>
    {
        public BGTargetsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Bgtargets GetSingle(int id)
        {
            return ctx.Bgtargets.FirstOrDefault(f => f.TargetId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.Bgtargets.FirstOrDefault(f => f.TargetId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
