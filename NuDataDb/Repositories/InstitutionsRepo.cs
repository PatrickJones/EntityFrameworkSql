using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class InstitutionsRepo : BaseRepo<Institutions, NuMedicsGlobalContext>
    {
        public InstitutionsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Institutions GetSingle(Guid id)
        {
            try
            {
                return ctx.Institutions.FirstOrDefault(f => f.InstitutionId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(Institutions)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(Guid id)
        {
            try
            {
                var del = ctx.Institutions.FirstOrDefault(f => f.InstitutionId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(Institutions)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public int InstitutionLowCount(Guid institutionId, int historyInDays)
        {
            try
            {
                return ctx.Institutions
                    .Where(w => w.InstitutionId == institutionId)
                    .Select(s => NuMedicsGlobalContext.InstitutionBloodGlucoseLowCount(institutionId, historyInDays))
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception($"Error retrieving institution low BG count from database. /n/r InstitutionId Id: {institutionId}", e);
            }
        }

        public int InstitutionHighCount(Guid institutionId, int historyInDays)
        {
            try
            {
                return ctx.Institutions
                    .Where(w => w.InstitutionId == institutionId)
                    .Select(s => NuMedicsGlobalContext.InstitutionBloodGlucoseHighCount(institutionId, historyInDays))
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception($"Error retrieving institution high BG count from database. /n/r InstitutionId Id: {institutionId}", e);
            }
        }

        public int InstitutionOnTargetCount(Guid institutionId, int historyInDays)
        {
            try
            {
                return ctx.Institutions
                    .Where(w => w.InstitutionId == institutionId)
                    .Select(s => NuMedicsGlobalContext.InstitutionBloodGlucoseOnTargetCount(institutionId, historyInDays))
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception($"Error retrieving institution on target BG count from database. /n/r InstitutionId Id: {institutionId}", e);
            }
        }
    }
}
