using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class SleepPattenLevelsRepo : BaseRepo<SleepPatternLevels, NuMedicsGlobalContext>
    {
        public SleepPattenLevelsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override SleepPatternLevels GetSingle(int id)
        {
            try
            {
                return ctx.SleepPatternLevels.FirstOrDefault(f => f.PatternId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(SleepPatternLevels)} entity from database. /n/r Entity Id: {id}", e); ;
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.SleepPatternLevels.FirstOrDefault(f => f.PatternId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(SleepPatternLevels)} entity from database. /n/r Entity Id: {id}", e); ;
            }
        }
    }
}
