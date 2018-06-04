using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class Users
    {
        public Users()
        {
            UserAuthentications = new HashSet<UserAuthentications>();
            AssignedUserTypes = new HashSet<AssignedUserTypes>();
        }

        public Guid UserId { get; set; }
        public DateTime CreationDate { get; set; }

        public Clinicians Clinicians { get; set; }
        public Patients Patients { get; set; }
        public ICollection<UserAuthentications> UserAuthentications { get; set; }
        public ICollection<AssignedUserTypes> AssignedUserTypes { get; set; }
    }
}
