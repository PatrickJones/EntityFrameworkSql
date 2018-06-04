using NuDataDb.EFNuEmails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.NuEmailsRepositories
{
    public class DomainTypesRepo : BaseRepo<DomainTypes, NuEmailsContext>
    {
        public DomainTypesRepo(NuEmailsContext dbContext) : base(dbContext)
        {
        }

        public override DomainTypes GetSingle(int id)
        {
            try
            {
                return ctx.DomainTypes.FirstOrDefault(f => f.DomainId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(DomainTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.DomainTypes.FirstOrDefault(f => f.DomainId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(DomainTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
