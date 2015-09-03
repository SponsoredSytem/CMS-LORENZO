namespace TMD.Models.DomainModels
{
    public class Event
    {
        public long EventId { get; set; }
        public string EventDescription { get; set; }
        public System.DateTime EventDate { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public long CompanyId { get; set; }
        public int EventStatusId { get; set; }
        public System.DateTime ReminderDate { get; set; }
        public string ReminderNote { get; set; }
        public int EventLengthMinutes { get; set; }
        public int EventType { get; set; }



        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Company Company { get; set; }
        public virtual EventStatus EventStatus { get; set; }
    }
}
