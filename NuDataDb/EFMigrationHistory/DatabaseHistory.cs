using System;
using System.Collections.Generic;

namespace NuDataDb.EFMigrationHistory
{
    public partial class DatabaseHistory
    {
        public DatabaseHistory()
        {
            PatientHistory = new HashSet<PatientHistory>();
            TableHistory = new HashSet<TableHistory>();
            UserHistory = new HashSet<UserHistory>();
        }

        public int MigrationId { get; set; }
        public string InstitutionName { get; set; }
        public int SiteId { get; set; }
        public DateTime LastMigrationDate { get; set; }
        public string FbConnectionStringUsed { get; set; }
        public string MigrationLog { get; set; }

        public ICollection<PatientHistory> PatientHistory { get; set; }
        public ICollection<TableHistory> TableHistory { get; set; }
        public ICollection<UserHistory> UserHistory { get; set; }
    }
}
