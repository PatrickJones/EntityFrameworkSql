using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class SharedAreas
    {
        public int ShareId { get; set; }
        public int SharedCategoryId { get; set; }
        public int RequestId { get; set; }

        public virtual DataShareRequestLog Request { get; set; }
    }
}
