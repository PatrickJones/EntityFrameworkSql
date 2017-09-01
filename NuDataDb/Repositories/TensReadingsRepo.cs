using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class TensReadingsRepo : BaseRepo<TensReadings>
    {
        public TensReadingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override TensReadings GetSingle(int id)
        {
            try
            {
                return ctx.TensReadings.FirstOrDefault(f => f.ReadingId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(TensReadings)} entity from database. /n/r Entity Id: {id}", e);throw;
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.TensReadings.FirstOrDefault(f => f.ReadingId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(TensReadings)} entity from database. /n/r Entity Id: {id}", e);;
            }
        }
    }
}
