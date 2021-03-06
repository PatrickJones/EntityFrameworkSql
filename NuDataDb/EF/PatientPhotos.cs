﻿using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class PatientPhotos
    {
        public int PhotoId { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public Guid UserId { get; set; }
        public bool? IsClinical { get; set; }

        public Patients User { get; set; }
    }
}
