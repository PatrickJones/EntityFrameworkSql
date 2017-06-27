using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PumpProgramsRepo : BaseRepo<PumpPrograms>
    {
        public PumpProgramsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PumpPrograms GetSingle(int id)
        {
            return ctx.PumpPrograms.FirstOrDefault(f => f.PumpProgramId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.PumpPrograms.FirstOrDefault(f => f.PumpProgramId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
