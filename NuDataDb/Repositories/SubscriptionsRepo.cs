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
            return ctx.Subscriptions.FirstOrDefault(f => f.SubscriptionId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.Subscriptions.FirstOrDefault(f => f.SubscriptionId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
