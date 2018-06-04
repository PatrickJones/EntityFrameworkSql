using System;
using System.Collections.Generic;
using System.Text;

namespace NuDataDb.EF
{
    public partial class EmailUsernameView
    {
        public Guid UserId { get; set; }
        public int UserType { get; set; }
        public DateTime CreationDate { get; set; }
        public string ClinicianEmail { get; set; }
        public string PatientEmail { get; set; }
    }
}
