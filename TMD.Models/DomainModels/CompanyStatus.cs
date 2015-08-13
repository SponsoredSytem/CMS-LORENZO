namespace TMD.Models.DomainModels
{
    public class CompanyStatus
    {
        public int StatusId { get; set; }
        public string StatusTitle { get; set; }
        public string StatusDescription { get; set; }
        public int SortOrder { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
    }
}
