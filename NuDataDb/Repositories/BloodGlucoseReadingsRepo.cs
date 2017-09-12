using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class BloodGlucoseReadingsRepo : BaseRepo<BloodGlucoseReadings, NuMedicsGlobalContext>
    {
        public BloodGlucoseReadingsRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override BloodGlucoseReadings GetSingle(Int64 id)
        {
            try
            {
                return ctx.BloodGlucoseReadings.FirstOrDefault(f => f.ReadingId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(BloodGlucoseReadings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override BloodGlucoseReadings GetSingle(int id)
        {
            try
            {
                return ctx.BloodGlucoseReadings.FirstOrDefault(f => f.ReadingId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(BloodGlucoseReadings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(Int64 id)
        {
            try
            {
                var del = ctx.BloodGlucoseReadings.FirstOrDefault(f => f.ReadingId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(BloodGlucoseReadings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.BloodGlucoseReadings.FirstOrDefault(f => f.ReadingId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(BloodGlucoseReadings)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
