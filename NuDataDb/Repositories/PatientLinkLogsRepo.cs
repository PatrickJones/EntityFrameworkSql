using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PatientLinkLogsRepo : BaseRepo<PatientLinkLogs>
    {
        public PatientLinkLogsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PatientLinkLogs GetSingle(int id)
        {
            return ctx.PatientLinkLogs.FirstOrDefault(f => f.LinkId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.PatientLinkLogs.FirstOrDefault(f => f.LinkId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
