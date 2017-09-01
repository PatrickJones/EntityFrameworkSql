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
            try
            {
                return ctx.UserAuthentications.FirstOrDefault(f => f.AuthenticationId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(UserAuthentications)} entity from database. /n/r Entity Id: {id}", e);;
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.UserAuthentications.FirstOrDefault(f => f.AuthenticationId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(UserAuthentications)} entity from database. /n/r Entity Id: {id}", e);;
            }
        }
    }
}
