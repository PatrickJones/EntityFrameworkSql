using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PatientPhotosRepo : BaseRepo<PatientPhotos, NuMedicsGlobalContext>
    {
        public PatientPhotosRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PatientPhotos GetSingle(Guid id)
        {
            try
            {
                return ctx.PatientPhotos.FirstOrDefault(f => f.UserId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(PatientPhotos)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(Guid id)
        {
            try
            {
                var del = ctx.PatientPhotos.FirstOrDefault(f => f.UserId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(PatientPhotos)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
