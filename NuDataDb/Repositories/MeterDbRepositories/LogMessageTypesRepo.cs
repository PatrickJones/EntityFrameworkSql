using NuDataDb.EFMetersDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.MeterDbRepositories
{
    public class LogMessageTypesRepo : BaseRepo<LogMessageTypes, MeterDevicesDbContext>
    {
        protected LogMessageTypesRepo(MeterDevicesDbContext dbContext) : base(dbContext)
        {
        }

        public override LogMessageTypes GetSingle(int id)
        {
            try
            {
                return ctx.LogMessageTypes.FirstOrDefault(f => f.Code == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(LogMessageTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.LogMessageTypes.FirstOrDefault(f => f.Code == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(LogMessageTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
