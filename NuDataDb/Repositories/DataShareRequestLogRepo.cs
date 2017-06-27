using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class DataShareRequestLogRepo : BaseRepo<DataShareRequestLog>
    {
        public DataShareRequestLogRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override DataShareRequestLog GetSingle(int id)
        {
            return ctx.DataShareRequestLog.FirstOrDefault(f => f.RequestId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.DataShareRequestLog.FirstOrDefault(f => f.RequestId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
