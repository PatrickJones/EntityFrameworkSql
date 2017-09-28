using System;
using System.Collections.Generic;

namespace NuDataDb.EFMigrationHistory
{
    public partial class PatientHistory
    {
        public int PatientHistoryId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public string FirebirdPatientId { get; set; }
        public Guid SqlUserId { get; set; }
        public DateTime MigrationDate { get; set; }
        public int MigrationId { get; set; }

        public DatabaseHistory Migration { get; set; }
    }
}
