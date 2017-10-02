using Microsoft.EntityFrameworkCore;
using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class EmailUsernameViewRepo : BaseRepo<EmailUsernameView, NuMedicsGlobalContext>
    {
        public EmailUsernameViewRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<EmailUsernameView> GetAsQueryable()
        {
            return ctx.Set<EmailUsernameView>().FromSql("SELECT * FROM EmailUsernameView").AsQueryable<EmailUsernameView>();
        }

        public override IEnumerable<EmailUsernameView> Get()
        {
            return ctx.Set<EmailUsernameView>().FromSql("SELECT * FROM EmailUsernameView");
        }
    }
}
