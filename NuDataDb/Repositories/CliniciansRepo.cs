using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class CliniciansRepo : BaseRepo<Clinicians>
    {
        public CliniciansRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Clinicians GetSingle(Guid id)
        {
            return ctx.Clinicians.FirstOrDefault(f => f.UserId == id);
        }

        public override void Delete(Guid id)
        {
            var del = ctx.Clinicians.FirstOrDefault(f => f.UserId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
