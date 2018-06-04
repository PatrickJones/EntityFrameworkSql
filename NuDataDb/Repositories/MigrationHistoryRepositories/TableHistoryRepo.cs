using NuDataDb.EFMigrationHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.MigrationHistoryRepositories
{
    public class TableHistoryRepo : BaseRepo<TableHistory, MigrationHistoryContext>
    {
        public TableHistoryRepo(MigrationHistoryContext dbContext) : base(dbContext)
        {
        }

        public override TableHistory GetSingle(int id)
        {
            try
            {
                return ctx.TableHistory.FirstOrDefault(f => f.MigrationId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(TableHistory)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.TableHistory.FirstOrDefault(f => f.MigrationId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(TableHistory)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
