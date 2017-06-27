using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PaymentMethodRepo : BaseRepo<PaymentMethod>
    {
        public PaymentMethodRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PaymentMethod GetSingle(int id)
        {
            return ctx.PaymentMethod.FirstOrDefault(f => f.MethodId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.PaymentMethod.FirstOrDefault(f => f.MethodId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
