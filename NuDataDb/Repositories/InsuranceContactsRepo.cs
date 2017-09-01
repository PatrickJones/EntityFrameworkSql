using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class InsuranceContactsRepo : BaseRepo<InsuranceContacts>
    {
        public InsuranceContactsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override InsuranceContacts GetSingle(int id)
        {
            try
            {
                return ctx.InsuranceContacts.FirstOrDefault(f => f.ContactId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(InsuranceContacts)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.InsuranceContacts.FirstOrDefault(f => f.ContactId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(InsuranceContacts)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
