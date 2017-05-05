using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class AppLoginHistories
    {
        public int HistoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LoginDate { get; set; }
        public Guid ApplicationId { get; set; }

        public virtual Applications Application { get; set; }
    }
}
