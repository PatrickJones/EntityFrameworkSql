using NuDataDb.EFNuEmails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.NuEmailsRepositories
{
    public class EmailCategoriesRepo : BaseRepo<EmailCategories, NuEmailsContext>
    {
        public EmailCategoriesRepo(NuEmailsContext dbContext) : base(dbContext)
        {
        }

        public override EmailCategories GetSingle(int id)
        {
            try
            {
                return ctx.EmailCategories.FirstOrDefault(f => f.EmailTypeId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(EmailCategories)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.EmailCategories.FirstOrDefault(f => f.EmailTypeId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(EmailCategories)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

    }
}
