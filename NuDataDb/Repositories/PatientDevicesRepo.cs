using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class PatientDevicesRepo : BaseRepo<PatientDevices>
    {
        public PatientDevicesRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override PatientDevices GetSingle(int id)
        {
            return ctx.PatientDevices.FirstOrDefault(f => f.DeviceId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.PatientDevices.FirstOrDefault(f => f.DeviceId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
