using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class ReadingErrors
    {
        public int ErrorId { get; set; }
        public DateTime Time { get; set; }
        public string ErrorName { get; set; }
        public string ErrorText { get; set; }
        public bool IsActive { get; set; }
        public Guid ReadingKeyId { get; set; }
        public Guid UserId { get; set; }

        public ReadingHeaders ReadingHeader { get; set; }
    }
}
