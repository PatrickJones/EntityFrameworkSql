using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class AssignedUserTypesRepo : BaseRepo<AssignedUserTypes, NuMedicsGlobalContext>
    {
        public AssignedUserTypesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override AssignedUserTypes GetSingle(int id)
        {
            try
            {
                return ctx.AssignedUserTypes.FirstOrDefault(f => f.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(AssignedUserTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.AssignedUserTypes.FirstOrDefault(f => f.Id == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(AssignedUserTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

    }
}
