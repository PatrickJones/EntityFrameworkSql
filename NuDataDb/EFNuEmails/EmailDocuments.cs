using System;
using System.Collections.Generic;

namespace NuDataDb.EFNuEmails
{
    public partial class EmailDocuments
    {
        public int DocumentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Html { get; set; }
        public string PlainText { get; set; }
        public string Xml { get; set; }
    }
}
