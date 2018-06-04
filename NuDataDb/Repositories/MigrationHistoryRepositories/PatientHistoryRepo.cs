using NuDataDb.EFMigrationHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.MigrationHistoryRepositories
{
    public class PatientHistoryRepo : BaseRepo<PatientHistory, MigrationHistoryContext>
    {
        public PatientHistoryRepo(MigrationHistoryContext dbContext) : base(dbContext)
        {
        }

        public override PatientHistory GetSingle(int id)
        {
            try
            {
                return ctx.PatientHistory.FirstOrDefault(f => f.PatientHistoryId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(PatientHistory)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.PatientHistory.FirstOrDefault(f => f.PatientHistoryId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(PatientHistory)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
