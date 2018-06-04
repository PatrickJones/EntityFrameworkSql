using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class UserTypesRepo : BaseRepo<UserTypes, NuMedicsGlobalContext>
    {
        public UserTypesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override UserTypes GetSingle(int id)
        {
            try
            {
                return ctx.UserTypes.FirstOrDefault(f => f.TypeId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(UserTypes)} entity from database. /n/r Entity Id: {id}", e);;
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.UserTypes.FirstOrDefault(f => f.TypeId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(UserTypes)} entity from database. /n/r Entity Id: {id}", e);;
            }
        }
    }
}
