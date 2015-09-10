using System;
using System.ComponentModel.DataAnnotations;

namespace TMD.Web.Models
{
    public class Company
    {
        public long CompanyId { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Company Legal Name")]
        public string LegalName { get; set; }
        [Display(Name = "Tax Number")]
        public string VATNumber { get; set; }
        [Display(Name = "Tax District")]
        public string VATOffice { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Comments")]
        public string Notes { get; set; }
        [Display(Name = "Description")]
        public string CompanyDescription { get; set; }
        public DateTime RecCreatedDate { get; set; }
        public DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
        [Display(Name = "Municipal")]
        public long? MunicipalId { get; set; }
        public long? CityId { get; set; }
        [Display(Name = "Source")]
        public long? SourceId { get; set; }
        public string CityName { get; set; }
        public string MunicipalName { get; set; }
        public string DeletedCompanyContacts { get; set; }
        public string AccountHolderId { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountHolderEmail { get; set; }
        public int? StatusId { get; set; }
        public string StatusTitle { get; set; }

        [Display(Name = "First Name")]
        public string IndividualFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string IndividualLastName { get; set; }
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }
        public string CompanyEventsUrl { get; set; }

        [Display(Name = "Is Company?")]
        public bool IsCompany { get; set; }
        public string Website { get; set; }

        [Display(Name = "Refrence Company")]
        public long? RefrenceCompanyId { get; set; }
        public long? BelongingCompanyId { get; set; }
    }
}