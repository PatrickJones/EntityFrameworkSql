using NuDataDb.EFNuEmails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.NuEmailsRepositories
{
    public class ServerLocationTypesRepo : BaseRepo<ServerLocationTypes, NuEmailsContext>
    {
        public ServerLocationTypesRepo(NuEmailsContext dbContext) : base(dbContext)
        {
        }

        public override ServerLocationTypes GetSingle(int id)
        {
            try
            {
                return ctx.ServerLocationTypes.FirstOrDefault(f => f.LocationId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(ServerLocationTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.ServerLocationTypes.FirstOrDefault(f => f.LocationId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(ServerLocationTypes)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
