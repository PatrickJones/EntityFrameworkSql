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
            try
            {
                return ctx.Payments.FirstOrDefault(f => f.PaymentId == id);
            }
            catch (Exception e)
            {

                throw new Exception($"Error getting {typeof(Payments)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.Payments.FirstOrDefault(f => f.PaymentId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(Payments)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
