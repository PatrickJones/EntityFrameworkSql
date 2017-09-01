using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class ReadingEventTypesRepo : BaseRepo<ReadingEventTypes>
    {
        public ReadingEventTypesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override ReadingEventTypes GetSingle(int id)
        {
            try
            {
                return ctx.ReadingEventTypes.FirstOrDefault(f => f.EventId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(ReadingEventTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.ReadingEventTypes.FirstOrDefault(f => f.EventId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(ReadingEventTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
