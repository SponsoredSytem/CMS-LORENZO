namespace TMD.Web.Models
{
    public class City
    {
        public long CityId { get; set; }
        public string CityName { get; set; }
        public string CityDescription { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
    }
}