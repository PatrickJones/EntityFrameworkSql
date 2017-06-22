using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class UserAuthenticationsRepo : BaseRepo<UserAuthentications>
    {
        public UserAuthenticationsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override UserAuthentications GetSingle(int id)
        {
            return ctx.UserAuthentications.FirstOrDefault(f => f.AuthenticationId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.UserAuthentications.FirstOrDefault(f => f.AuthenticationId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
