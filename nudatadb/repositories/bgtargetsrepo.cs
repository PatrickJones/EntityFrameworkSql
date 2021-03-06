using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class BGTargetsRepo : BaseRepo<Bgtargets, NuMedicsGlobalContext>
    {
        public BGTargetsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Bgtargets GetSingle(int id)
        {
            try
            {
                return ctx.Bgtargets.FirstOrDefault(f => f.TargetId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(Bgtargets)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.Bgtargets.FirstOrDefault(f => f.TargetId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(Bgtargets)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
