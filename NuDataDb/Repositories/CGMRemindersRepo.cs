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
            try
            {
                return ctx.Cgmreminders.FirstOrDefault(f => f.ReminderId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(Cgmreminders)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.Cgmreminders.FirstOrDefault(f => f.ReminderId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(Cgmreminders)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
