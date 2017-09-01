using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class SubscriptionsRepo : BaseRepo<Subscriptions>
    {
        public SubscriptionsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Subscriptions GetSingle(int id)
        {
            try
            {
                return ctx.Subscriptions.FirstOrDefault(f => f.SubscriptionId == id);
            }
            catch (Exception e) 
            {
                throw new Exception($"Error getting {typeof(SubscriptionsRepo)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.Subscriptions.FirstOrDefault(f => f.SubscriptionId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(SubscriptionsRepo)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
