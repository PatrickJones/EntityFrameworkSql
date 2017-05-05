using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class UserPhotos
    {
        public byte[] Photo { get; set; }
        public Guid UserId { get; set; }
    }
}
