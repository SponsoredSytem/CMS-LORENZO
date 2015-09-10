using System;
using System.Collections.Generic;

namespace TMD.Models.DomainModels
{
    public class Company
    {
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string LegalName { get; set; }
        public string VATNumber { get; set; }
        public string VATOffice { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public string CompanyDescription { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public long? MunicipalId { get; set; }
        public long? SourceId { get; set; }
        public string EmployeeId { get; set; }
        public int? StatusId { get; set; }
        public bool IsCompany { get; set; }
        public string Website { get; set; }
        public long? RefrenceCompanyId { get; set; }
        public string IndividualFirstName { get; set; }
        public string IndividualLastName { get; set; }
        public string CellPhone { get; set; }
        public long? CityId { get; set; }
        public long? BelongingCompanyId { get; set; }

        public virtual Municipal Municipal { get; set; }
        public virtual Source Source { get; set; }
        public virtual ICollection<CompanyContact> CompanyContacts { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual CompanyStatus CompanyStatus { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Company> CompaniesWhereIamRefrenced { get; set; }
        public virtual Company RefrenceCompany { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Company> BelongingsOfTheCompany { get; set; }
        public virtual Company BelongingCompany { get; set; }
    }
}
