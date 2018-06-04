using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PayPalRepo : BaseRepo<PayPal, NuMedicsGlobalContext>
    {
        public PayPalRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PayPal GetSingle(int id)
        {
            try
            {
                return ctx.PayPal.FirstOrDefault(f => f.PayPalId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(PayPal)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.PayPal.FirstOrDefault(f => f.PayPalId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(PayPal)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
