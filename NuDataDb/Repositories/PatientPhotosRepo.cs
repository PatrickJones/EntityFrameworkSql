using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PatientPhotosRepo : BaseRepo<PatientPhotos>
    {
        public PatientPhotosRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PatientPhotos GetSingle(Guid id)
        {
            return ctx.PatientPhotos.FirstOrDefault(f => f.UserId == id);
        }

        public override void Delete(Guid id)
        {
            var del = ctx.PatientPhotos.FirstOrDefault(f => f.UserId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
