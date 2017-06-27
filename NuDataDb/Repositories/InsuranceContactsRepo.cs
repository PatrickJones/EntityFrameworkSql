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
            return ctx.InsuranceContacts.FirstOrDefault(f => f.ContactId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.InsuranceContacts.FirstOrDefault(f => f.ContactId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
