using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string FistName { get; set; }
        public string SecondName { get; set; }

        // General data
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodType { get; set; }
        public string CivilStatus { get; set; }
        public string Occupation { get; set; }
        public string IdentificationDocument { get; set; }
        public string DocumentNumber { get; set; }
        public string NationalTaxpayerRegistry { get; set; }
        public string RepresentativeName { get; set; }
        public string RepresentatuveType { get; set; }

        // Localitation data
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string CityOrMunicipality { get; set; }

        // Security data
        public bool MedicalInsurance { get; set; }
        public string InsuranceCompany { get; set; }
        public string PolicyNumber { get; set; }
        public string CertficateNumber { get; set; }
        public string Relationship { get; set; }
        public string Observations { get; set; }


    }
}
