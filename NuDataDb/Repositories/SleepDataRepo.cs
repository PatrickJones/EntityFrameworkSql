using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class SleepDataRepo : BaseRepo<SleepData, NuMedicsGlobalContext>
    {
        public SleepDataRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override SleepData GetSingle(int id)
        {
            try
            {
                return ctx.SleepData.FirstOrDefault(f => f.SleepDataId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(SleepData)} entity from database. /n/r Entity Id: {id}", e); ;
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.SleepData.FirstOrDefault(f => f.SleepDataId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(SleepData)} entity from database. /n/r Entity Id: {id}", e); ;
            }
        }

    }
}
