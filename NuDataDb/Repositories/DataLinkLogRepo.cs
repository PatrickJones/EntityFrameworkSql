using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class DataLinkLogRepo : BaseRepo<DataLinkLog>
    {
        public DataLinkLogRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override DataLinkLog GetSingle(int id)
        {
            return ctx.DataLinkLog.FirstOrDefault(f => f.LinkId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.DataLinkLog.FirstOrDefault(f => f.LinkId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
