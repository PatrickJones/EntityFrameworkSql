using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories
{
    public class PasswordHistoriesRepo : BaseRepo<PasswordHistories>
    {
        public PasswordHistoriesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PasswordHistories GetSingle(int id)
        {
            return ctx.PasswordHistories.FirstOrDefault(f => f.HistoryId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.PasswordHistories.FirstOrDefault(f => f.HistoryId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
