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
            return ctx.SubscriptionType.FirstOrDefault(f => f.SubscriptionTypeId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.SubscriptionType.FirstOrDefault(f => f.SubscriptionTypeId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
