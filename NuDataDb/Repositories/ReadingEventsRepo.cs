using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class ReadingEventsRepo : BaseRepo<ReadingEvents>
    {
        public ReadingEventsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override ReadingEvents GetSingle(int id)
        {
            return ctx.ReadingEvents.FirstOrDefault(f => f.Eventid == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.ReadingEvents.FirstOrDefault(f => f.Eventid == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
