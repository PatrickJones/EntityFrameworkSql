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
            try
            {
                return ctx.DatabaseInfo.FirstOrDefault(f => f.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(DatabaseInfo)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.DatabaseInfo.FirstOrDefault(f => f.Id == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(DatabaseInfo)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
