namespace TMD.Models.DomainModels
{
    public class CompanyContact
    {
        public long CompanyContactId { get; set; }
        public long CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string PhoneCell { get; set; }
        public string PhoneLandLine { get; set; }
        public string Email { get; set; }
        public string ContactType { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

        public virtual Company Company { get; set; }
    }
}
