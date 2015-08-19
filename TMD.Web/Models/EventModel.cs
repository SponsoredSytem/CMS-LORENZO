using System.ComponentModel.DataAnnotations;

namespace TMD.Web.Models
{
    public class EventModel
    {
        public long EventId { get; set; }
        [Display(Name = "Event Description")]
        public string EventDescription { get; set; }
        [Display(Name = "Event Date")]
        public System.DateTime EventDate { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecCreatedByName { get; set; }
        public string RecLastUpdatedBy { get; set; }
    }
}