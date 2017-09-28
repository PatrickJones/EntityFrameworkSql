using NuDataDb.EFNuEmails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.NuEmailsRepositories
{
    public class EmailDocumentsRepo : BaseRepo<EmailDocuments, NuEmailsContext>
    {
        public EmailDocumentsRepo(NuEmailsContext dbContext) : base(dbContext)
        {
        }

        public override EmailDocuments GetSingle(int id)
        {
            try
            {
                return ctx.EmailDocuments.FirstOrDefault(f => f.DocumentId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(EmailDocuments)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.EmailDocuments.FirstOrDefault(f => f.DocumentId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(EmailDocuments)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

    }
}
