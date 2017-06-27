using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PayPalRepo : BaseRepo<PayPal>
    {
        public PayPalRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PayPal GetSingle(int id)
        {
            return ctx.PayPal.FirstOrDefault(f => f.PayPalId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.PayPal.FirstOrDefault(f => f.PayPalId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
