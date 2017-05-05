using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class Users
    {
        public Users()
        {
            UserAuthentications = new HashSet<UserAuthentications>();
        }

        public Guid UserId { get; set; }
        public int UserType { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Clinicians Clinicians { get; set; }
        public virtual Patients Patients { get; set; }
        public virtual ICollection<UserAuthentications> UserAuthentications { get; set; }
    }
}
