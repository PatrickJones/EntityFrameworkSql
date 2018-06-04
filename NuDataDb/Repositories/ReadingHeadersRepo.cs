using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class ReadingHeadersRepo : BaseRepo<ReadingHeaders, NuMedicsGlobalContext>
    {
        public ReadingHeadersRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override ReadingHeaders GetSingle(Guid id)
        {
            try
            {
                return ctx.ReadingHeaders.FirstOrDefault(f => f.ReadingKeyId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(ReadingHeaders)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(Guid id)
        {
            try
            {
                var del = ctx.ReadingHeaders.FirstOrDefault(f => f.ReadingKeyId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(ReadingHeaders)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
