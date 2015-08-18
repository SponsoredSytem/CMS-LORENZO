namespace TMD.Web.Models
{
    public class SizeModel
    {
        public int SizeId { get; set; }
        public string SizeTitle { get; set; }
        public string SizeValue { get; set; }
        public string SizeDescription { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
    }
}