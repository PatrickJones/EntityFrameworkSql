using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class InstitutionsRepo : BaseRepo<Institutions>
    {
        public InstitutionsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Institutions GetSingle(Guid id)
        {
            try
            {
                return ctx.Institutions.FirstOrDefault(f => f.InstitutionId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(Institutions)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(Guid id)
        {
            try
            {
                var del = ctx.Institutions.FirstOrDefault(f => f.InstitutionId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(Institutions)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
