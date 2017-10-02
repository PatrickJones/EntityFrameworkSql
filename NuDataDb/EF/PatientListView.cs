using System;
using System.Collections.Generic;
using System.Text;

namespace NuDataDb.EF
{
    public partial class PatientListView
    {
        public Guid InstitutionId { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string InstitutionName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Email { get; set; }
        public DateTime DateofBirth { get; set; }
        public string MRID { get; set; }
    }
}
