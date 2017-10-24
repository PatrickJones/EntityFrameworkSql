using Microsoft.EntityFrameworkCore;
using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class SubscriptionsViewRepo : BaseRepo<SubscriptionsView, NuMedicsGlobalContext>
    {
        protected SubscriptionsViewRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<SubscriptionsView> GetAsQueryable()
        {
            return ctx.Set<SubscriptionsView>().FromSql("SELECT * FROM SubscriptionsView").AsQueryable<SubscriptionsView>();
        }

        public override IEnumerable<SubscriptionsView> Get()
        {
            return ctx.Set<SubscriptionsView>().FromSql("SELECT * FROM SubscriptionsView");
        }
    }
}
