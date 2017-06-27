using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class DatabaseInfoRepo : BaseRepo<DatabaseInfo>
    {
        public DatabaseInfoRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override DatabaseInfo GetSingle(int id)
        {
            return ctx.DatabaseInfo.FirstOrDefault(f => f.Id == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.DatabaseInfo.FirstOrDefault(f => f.Id == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
