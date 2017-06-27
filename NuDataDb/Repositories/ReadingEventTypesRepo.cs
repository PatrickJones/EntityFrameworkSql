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
            return ctx.ReadingEventTypes.FirstOrDefault(f => f.EventId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.ReadingEventTypes.FirstOrDefault(f => f.EventId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
