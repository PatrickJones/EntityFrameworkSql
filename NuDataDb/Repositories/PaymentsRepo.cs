using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PaymentsRepo : BaseRepo<Payments>
    {
        public PaymentsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override Payments GetSingle(int id)
        {
            return ctx.Payments.FirstOrDefault(f => f.PaymentId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.Payments.FirstOrDefault(f => f.PaymentId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
