using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PatientsRepo : BaseRepo<Patients, NuMedicsGlobalContext>
    {
        public PatientsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Patients GetSingle(Guid id)
        {
            try
            {
                return ctx.Patients.FirstOrDefault(f => f.UserId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(Patients)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(Guid id)
        {
            try
            {
                var del = ctx.Patients.FirstOrDefault(f => f.UserId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(Patients)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
