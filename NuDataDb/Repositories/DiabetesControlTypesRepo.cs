using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class DiabetesControlTypesRepo : BaseRepo<DiabetesControlTypes>
    {
        public DiabetesControlTypesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override DiabetesControlTypes GetSingle(int id)
        {
            try
            {
                return ctx.DiabetesControlTypes.FirstOrDefault(f => f.TypeId == id);
            }
            catch (Exception e)
            {
                throw;throw new Exception($"Error getting {typeof(DiabetesControlTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.DiabetesControlTypes.FirstOrDefault(f => f.TypeId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw;throw new Exception($"Error deleting {typeof(DiabetesControlTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
