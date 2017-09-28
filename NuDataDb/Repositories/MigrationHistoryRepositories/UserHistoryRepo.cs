using NuDataDb.EFMigrationHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.MigrationHistoryRepositories
{
    public class UserHistoryRepo : BaseRepo<UserHistory, MigrationHistoryContext>
    {
        public UserHistoryRepo(MigrationHistoryContext dbContext) : base(dbContext)
        {
        }

        public override UserHistory GetSingle(int id)
        {
            try
            {
                return ctx.UserHistory.FirstOrDefault(f => f.MigrationId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(UserHistory)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.UserHistory.FirstOrDefault(f => f.MigrationId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(UserHistory)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
