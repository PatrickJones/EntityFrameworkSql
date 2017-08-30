using System;
using System.Collections.Generic;
using System.Text;

namespace NuDataDb.EF
{
    public partial class SharedAreas
    {
        public int ShareId { get; set; }
        public int DataShareCategoryId { get; set; }
        public int RequestId { get; set; }

        public virtual DataShareRequestLog Request { get; set; }
    }
}
