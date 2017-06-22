using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class UsersRepo : BaseRepo<Users>
    {
        public UsersRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Users GetSingle(Guid id)
        {
            return ctx.Users.FirstOrDefault(f => f.UserId == id);
        }

        public override void Delete(Guid id)
        {
            var del = ctx.Users.FirstOrDefault(f => f.UserId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }

    }
}
