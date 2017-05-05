using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class Patients
    {
        public Patients()
        {
            CareSettings = new HashSet<CareSettings>();
            PatientAddresses = new HashSet<PatientAddresses>();
            PatientDevices = new HashSet<PatientDevices>();
            PatientPhoneNumbers = new HashSet<PatientPhoneNumbers>();
            PatientsInstitutions = new HashSet<PatientsInstitutions>();
            PatientsInsurancePlans = new HashSet<PatientsInsurancePlans>();
            Subscriptions = new HashSet<Subscriptions>();
        }

        public Guid UserId { get; set; }
        public string Mrid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public int Gender { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Race { get; set; }
        public int PlanId { get; set; }
        public string Email { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid LastUpdatedByUser { get; set; }

        public virtual ICollection<CareSettings> CareSettings { get; set; }
        public virtual ICollection<PatientAddresses> PatientAddresses { get; set; }
        public virtual ICollection<PatientDevices> PatientDevices { get; set; }
        public virtual ICollection<PatientPhoneNumbers> PatientPhoneNumbers { get; set; }
        public virtual ICollection<PatientsInstitutions> PatientsInstitutions { get; set; }
        public virtual ICollection<PatientsInsurancePlans> PatientsInsurancePlans { get; set; }
        public virtual ICollection<Subscriptions> Subscriptions { get; set; }
        public virtual Users User { get; set; }
    }
}
