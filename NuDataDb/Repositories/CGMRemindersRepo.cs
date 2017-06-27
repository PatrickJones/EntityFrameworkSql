using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class CGMRemindersRepo : BaseRepo<Cgmreminders>
    {
        public CGMRemindersRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Cgmreminders GetSingle(int id)
        {
            return ctx.Cgmreminders.FirstOrDefault(f => f.ReminderId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.Cgmreminders.FirstOrDefault(f => f.ReminderId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
