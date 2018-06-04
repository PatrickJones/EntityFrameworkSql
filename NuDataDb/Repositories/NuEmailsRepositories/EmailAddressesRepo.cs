using NuDataDb.EFNuEmails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.NuEmailsRepositories
{
    public class EmailAddressesRepo : BaseRepo<EmailAddresses, NuEmailsContext>
    {
        public EmailAddressesRepo(NuEmailsContext dbContext) : base(dbContext)
        {
        }

        public override EmailAddresses GetSingle(int id)
        {
            try
            {
                return ctx.EmailAddresses.FirstOrDefault(f => f.AddressId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(EmailAddresses)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.EmailAddresses.FirstOrDefault(f => f.AddressId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(EmailAddresses)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

    }
}
