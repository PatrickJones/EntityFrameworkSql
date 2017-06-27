using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class DeviceDataRepo : BaseRepo<DeviceData>
    {
        public DeviceDataRepo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override DeviceData GetSingle(int id)
        {
            return ctx.DeviceData.FirstOrDefault(f => f.DataSetId == id);
        }

        public override void Delete(int id)
        {
            var del = ctx.DeviceData.FirstOrDefault(f => f.DataSetId == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
