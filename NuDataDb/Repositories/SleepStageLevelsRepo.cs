using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class SleepStageLevelsRepo : BaseRepo<SleepStageLevels, NuMedicsGlobalContext>
    {
        public SleepStageLevelsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override SleepStageLevels GetSingle(int id)
        {
            try
            {
                return ctx.SleepStageLevels.FirstOrDefault(f => f.StageId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(SleepStageLevels)} entity from database. /n/r Entity Id: {id}", e); ;
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.SleepStageLevels.FirstOrDefault(f => f.StageId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(SleepStageLevels)} entity from database. /n/r Entity Id: {id}", e); ;
            }
        }

    }
}
