using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class UserPhotosRepo : BaseRepo<UserPhotos>
    {
        public UserPhotosRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override UserPhotos GetSingle(Guid id)
        {
            return ctx.UserPhotos.FirstOrDefault(f => f.UserId == id);
        }

        public override void Delete(Guid id)
        {
            var del = ctx.UserPhotos.FirstOrDefault(f => f.UserId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
