using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class DataShareRequestLogRepo : BaseRepo<DataShareRequestLog, NuMedicsGlobalContext>
    {
        public DataShareRequestLogRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override DataShareRequestLog GetSingle(int id)
        {
            try
            {
                return ctx.DataShareRequestLog.FirstOrDefault(f => f.RequestId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(DataShareRequestLog)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.DataShareRequestLog.FirstOrDefault(f => f.RequestId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(DataShareRequestLog)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
