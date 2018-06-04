using NuDataDb.EFGlobalStandards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.GlobalStandardsRepositories
{
    public class ExercisesRepo : BaseRepo<Exercises, GlobalStandardsContext>
    {
        public ExercisesRepo(GlobalStandardsContext dbContext) : base(dbContext)
        {
        }

        public override Exercises GetSingle(int id)
        {
            try
            {
                return ctx.Exercises.FirstOrDefault(f => f.ExerciseId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(Exercises)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.Exercises.FirstOrDefault(f => f.ExerciseId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(Exercises)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

    }
}
