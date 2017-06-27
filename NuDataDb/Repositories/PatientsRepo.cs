using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PatientsRepo : BaseRepo<Patients>
    {
        public PatientsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Patients GetSingle(Guid id)
        {
            return ctx.Patients.FirstOrDefault(f => f.UserId == id);
        }

        public override void Delete(Guid id)
        {
            var del = ctx.Patients.FirstOrDefault(f => f.UserId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
