using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class CliniciansRepo : BaseRepo<Clinicians, NuMedicsGlobalContext>
    {
        public CliniciansRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Clinicians GetSingle(Guid id)
        {
            try
            {
                return ctx.Clinicians.FirstOrDefault(f => f.UserId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(Clinicians)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(Guid id)
        {
            try
            {
                var del = ctx.Clinicians.FirstOrDefault(f => f.UserId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(Clinicians)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
