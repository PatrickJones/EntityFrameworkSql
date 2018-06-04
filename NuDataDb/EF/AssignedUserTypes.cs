using System;
using System.Collections.Generic;
using System.Text;

namespace NuDataDb.EF
{
    public partial class AssignedUserTypes
    {
        public int Id { get; set; }
        public int UserType { get; set; }
        public Guid UserId { get; set; }

        public Users User { get; set; }
    }
}
