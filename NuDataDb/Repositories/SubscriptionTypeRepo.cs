using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class SubscriptionTypeRepo : BaseRepo<SubscriptionType>
    {
        public SubscriptionTypeRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override SubscriptionType GetSingle(int id)
        {
            try
            {
                return ctx.SubscriptionType.FirstOrDefault(f => f.SubscriptionTypeId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(SubscriptionType)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.SubscriptionType.FirstOrDefault(f => f.SubscriptionTypeId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(SubscriptionType)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
