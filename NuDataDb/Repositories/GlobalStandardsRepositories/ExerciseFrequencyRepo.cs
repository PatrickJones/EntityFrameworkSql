using NuDataDb.EFGlobalStandards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.GlobalStandardsRepositories
{
    public class ExerciseFrequencyRepo : BaseRepo<ExerciseFrequency, GlobalStandardsContext>
    {
        public ExerciseFrequencyRepo(GlobalStandardsContext dbContext) : base(dbContext)
        {
        }

        public override ExerciseFrequency GetSingle(int id)
        {
            try
            {
                return ctx.ExerciseFrequency.FirstOrDefault(f => f.FrequencyId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(ExerciseFrequency)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.ExerciseFrequency.FirstOrDefault(f => f.FrequencyId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(ExerciseFrequency)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
