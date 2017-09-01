using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PatientsInstitutionsRepo : BaseRepo<PatientsInstitutions>
    {
        public PatientsInstitutionsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PatientsInstitutions GetSingle(Guid id)
        {
            try
            {
                return ctx.PatientsInstitutions.FirstOrDefault(f => f.UserId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(PatientsInstitutions)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(Guid id)
        {
            try
            {
                var del = ctx.PatientsInstitutions.FirstOrDefault(f => f.UserId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(PatientsInstitutions)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public void Delete(Guid userId, Guid institutionId)
        {
            try
            {
                var del = ctx.PatientsInstitutions.FirstOrDefault(f => f.UserId == userId && f.InstitutionId == institutionId);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(PatientsInstitutions)} entity from database using UserId and InstitutionId. /n/r Users Id: {userId} and Institution Id: {institutionId}", e);
            }
        }
    }
}
