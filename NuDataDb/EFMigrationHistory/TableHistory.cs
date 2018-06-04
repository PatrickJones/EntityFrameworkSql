using System;
using System.Collections.Generic;

namespace NuDataDb.EFMigrationHistory
{
    public partial class TableHistory
    {
        public int TableMigrationId { get; set; }
        public string TableName { get; set; }
        public long FirebirdRecordCount { get; set; }
        public long MigratedRecordCount { get; set; }
        public DateTime LastMigrationDate { get; set; }
        public int MigrationId { get; set; }

        public DatabaseHistory Migration { get; set; }
    }
}
