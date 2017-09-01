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
            try
            {
                return ctx.Users.FirstOrDefault(f => f.UserId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(Users)} entity from database. /n/r Entity Id: {id}", e);;
            }
        }

        public override void Delete(Guid id)
        {
            try
            {
                var del = ctx.Users.FirstOrDefault(f => f.UserId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(Users)} entity from database. /n/r Entity Id: {id}", e);;
            }
        }

    }
}
