using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class InsulinCorrectionsRepo : BaseRepo<InsulinCorrections>
    {
        public InsulinCorrectionsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override InsulinCorrections GetSingle(int id)
        {
            return ctx.InsulinCorrections.FirstOrDefault(f => f.CorrectionId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.InsulinCorrections.FirstOrDefault(f => f.CorrectionId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
