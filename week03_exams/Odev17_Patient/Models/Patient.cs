using System;

namespace Odev17_Patient.Models
{
    public class Patient
    {
        // Auto-property'ler
        public string PatientId { get; set; } = "";
        public string FullName { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public string BloodType { get; set; } = "";
    }
}