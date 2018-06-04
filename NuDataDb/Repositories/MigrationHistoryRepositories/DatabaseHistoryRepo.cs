using NuDataDb.EFMigrationHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.MigrationHistoryRepositories
{
    public class DatabaseHistoryRepo: BaseRepo<DatabaseHistory, MigrationHistoryContext>
    {
        public DatabaseHistoryRepo(MigrationHistoryContext dbContext) : base(dbContext)
        {
        }

        public override DatabaseHistory GetSingle(int id)
        {
            try
            {
                return ctx.DatabaseHistory.FirstOrDefault(f => f.MigrationId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(DatabaseHistory)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.DatabaseHistory.FirstOrDefault(f => f.MigrationId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(DatabaseHistory)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
