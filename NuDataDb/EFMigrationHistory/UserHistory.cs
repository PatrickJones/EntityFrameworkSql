using System;
using System.Collections.Generic;

namespace NuDataDb.EFMigrationHistory
{
    public partial class UserHistory
    {
        public int HistoryId { get; set; }
        public string Username { get; set; }
        public Guid SqlUserId { get; set; }
        public Guid LegacyUserId { get; set; }
        public int MigrationId { get; set; }
        public DateTime MigrationDate { get; set; }

        public DatabaseHistory Migration { get; set; }
    }
}
