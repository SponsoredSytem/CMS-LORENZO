using System;
using System.ComponentModel.DataAnnotations;

namespace TMD.Web.Models
{
    public class Company
    {
        public long CompanyId { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Legal Name")]
        public string LegalName { get; set; }
        [Display(Name = "V.A.T Number")]
        public string VATNumber { get; set; }
        [Display(Name = "V.A.T Office")]
        public string VATOffice { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Description")]
        public string CompanyDescription { get; set; }
        public DateTime RecCreatedDate { get; set; }
        public DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
        [Display(Name = "Municipal")]
        public long? MunicipalId { get; set; }
        public long CityId { get; set; }
        [Display(Name = "Source")]
        public long? SourceId { get; set; }
        public string CityName { get; set; }
        public string MunicipalName { get; set; }
        public string DeletedCompanyContacts { get; set; }
    }
}