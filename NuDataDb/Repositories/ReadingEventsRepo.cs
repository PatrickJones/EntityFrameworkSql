using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class ReadingEventsRepo : BaseRepo<ReadingEvents, NuMedicsGlobalContext>
    {
        public ReadingEventsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override ReadingEvents GetSingle(int id)
        {
            try
            {
                return ctx.ReadingEvents.FirstOrDefault(f => f.Eventid == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(ReadingEvents)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.ReadingEvents.FirstOrDefault(f => f.Eventid == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(ReadingEvents)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
