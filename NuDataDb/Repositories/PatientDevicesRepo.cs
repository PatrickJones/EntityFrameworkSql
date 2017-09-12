using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PatientDevicesRepo : BaseRepo<PatientDevices, NuMedicsGlobalContext>
    {
        public PatientDevicesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PatientDevices GetSingle(int id)
        {
            try
            {
                return ctx.PatientDevices.FirstOrDefault(f => f.DeviceId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(PatientDevices)} entity from database. /n/r Entity Id: {id}", e);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var del = ctx.PatientDevices.FirstOrDefault(f => f.DeviceId == id);
                if (del != null)
                {
                    ctx.Remove(del);
                    Save();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting {typeof(PatientDevices)} entity from database. /n/r Entity Id: {id}", e);
            }
        }
    }
}
