using NuDataDb.EFMetersDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Repositories.MeterDbRepositories
{
    public class MetersRepo : BaseRepo<Meters, MeterDevicesDbContext>
    {
        protected MetersRepo(MeterDevicesDbContext dbContext) : base(dbContext)
        {
        }

        public override Meters GetSingle(int id)
        {
            try
            {
                return ctx.Meters.FirstOrDefault(f => f.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(Meters)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.Meters.FirstOrDefault(f => f.Id == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(Meters)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
