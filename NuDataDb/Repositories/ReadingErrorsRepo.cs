using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class ReadingErrorsRepo : BaseRepo<ReadingErrors, NuMedicsGlobalContext>
    {
        public ReadingErrorsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override ReadingErrors GetSingle(int id)
        {
            try
            {
                return ctx.ReadingErrors.FirstOrDefault(f => f.ErrorId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(ReadingErrors)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.ReadingErrors.FirstOrDefault(f => f.ErrorId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(ReadingErrors)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
