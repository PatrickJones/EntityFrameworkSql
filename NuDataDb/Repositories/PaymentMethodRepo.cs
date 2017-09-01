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
            try
            {
                return ctx.PaymentMethod.FirstOrDefault(f => f.MethodId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(PaymentMethod)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.PaymentMethod.FirstOrDefault(f => f.MethodId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(PaymentMethod)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
