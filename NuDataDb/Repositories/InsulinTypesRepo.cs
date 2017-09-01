using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class InsulinTypesRepo : BaseRepo<InsulinTypes>
    {
        public InsulinTypesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override InsulinTypes GetSingle(int id)
        {
            try
            {
                return ctx.InsulinTypes.FirstOrDefault(f => f.InsulinTypeId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(InsulinTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.InsulinTypes.FirstOrDefault(f => f.InsulinTypeId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(InsulinTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
