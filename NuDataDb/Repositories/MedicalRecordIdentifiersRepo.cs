using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class MedicalRecordIdentifiersRepo : BaseRepo<MedicalRecordIdentifiers, NuMedicsGlobalContext>
    {
        public MedicalRecordIdentifiersRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override MedicalRecordIdentifiers GetSingle(int id)
        {
            try
            {
                return ctx.MedicalRecordIdentifiers.FirstOrDefault(f => f.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(MedicalRecordIdentifiers)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.MedicalRecordIdentifiers.FirstOrDefault(f => f.Id == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(MedicalRecordIdentifiers)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

    }
}
