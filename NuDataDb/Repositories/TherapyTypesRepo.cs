using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class TherapyTypesRepo : BaseRepo<TherapyTypes, NuMedicsGlobalContext>
    {
        public TherapyTypesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override TherapyTypes GetSingle(int id)
        {
            try
            {
                return ctx.TherapyTypes.FirstOrDefault(f => f.TypeId == id);
            }
            catch (Exception e) 
            {
                throw new Exception($"Error getting {typeof(TherapyTypes)} entity from database. /n/r Entity Id: {id}", e);;
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.TherapyTypes.FirstOrDefault(f => f.TypeId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(TherapyTypes)} entity from database. /n/r Entity Id: {id}", e);;
            }
        }
    }
}
