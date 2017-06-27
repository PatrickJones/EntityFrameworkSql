using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class ReadingErrorsRepo : BaseRepo<ReadingErrors>
    {
        public ReadingErrorsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override ReadingErrors GetSingle(int id)
        {
            return ctx.ReadingErrors.FirstOrDefault(f => f.ErrorId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.ReadingErrors.FirstOrDefault(f => f.ErrorId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
