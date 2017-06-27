using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class UserTypesRepo : BaseRepo<UserTypes>
    {
        public UserTypesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override UserTypes GetSingle(int id)
        {
            return ctx.UserTypes.FirstOrDefault(f => f.TypeId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.UserTypes.FirstOrDefault(f => f.TypeId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
