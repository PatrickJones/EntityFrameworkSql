using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class DiabetesManagementDataRepo : BaseRepo<DiabetesManagementData, NuMedicsGlobalContext>
    {
        public DiabetesManagementDataRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override DiabetesManagementData GetSingle(int id)
        {
            try
            {
                return ctx.DiabetesManagementData.FirstOrDefault(f => f.DmdataId == id);
            }
            catch (Exception e)
            {
                throw;throw new Exception($"Error getting {typeof(DiabetesManagementData)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.DiabetesManagementData.FirstOrDefault(f => f.DmdataId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw;throw new Exception($"Error deleting {typeof(DiabetesManagementData)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
