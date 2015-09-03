using System.ComponentModel.DataAnnotations;

namespace TMD.Web.Models
{
    public class EventModel
    {
        public long EventId { get; set; }
        [Display(Name = "Company")]
        public long CompanyId { get; set; }
        [Display(Name = "Event Status")]
        public int StatusId { get; set; }
        public string StatusTitle { get; set; }
        public string CompanyName { get; set; }
        [Display(Name = "Event Description")]
        public string EventDescription { get; set; }
        [Display(Name = "Event Date")]
        public System.DateTime EventDate { get; set; }
        [Display(Name = "Reminder Date")]
        public System.DateTime ReminderDate { get; set; }
        [Display(Name = "Reminder Note")]
        public string ReminderNote { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecCreatedByName { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public string EventDateString { get; set; }
        public string ReminderDateString { get; set; }

        public int EventDuration { get; set; }

    }
}