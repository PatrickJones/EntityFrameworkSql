using System;
using System.Collections.Generic;
using System.Text;

namespace NuDataDb.EF
{
    public partial class PasswordHistories
    {
        public int HistoryId { get; set; }
        public string Password { get; set; }
        public Guid UserId { get; set; }
        public DateTime LastDateUsed { get; set; }
        public int AuthenticationId { get; set; }

        public virtual UserAuthentications Authentication { get; set; }
    }
}
