using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class ReadingHeadersRepo : BaseRepo<ReadingHeaders>
    {
        public ReadingHeadersRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override ReadingHeaders GetSingle(Guid id)
        {
            return ctx.ReadingHeaders.FirstOrDefault(f => f.ReadingKeyId == id);
        }

        public override void Delete(Guid id)
        {
            var del = ctx.ReadingHeaders.FirstOrDefault(f => f.ReadingKeyId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
