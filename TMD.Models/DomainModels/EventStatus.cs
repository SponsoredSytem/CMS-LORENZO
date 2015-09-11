using System.Collections.Generic;

namespace TMD.Models.DomainModels
{
    public class EventStatus
    {
        public int StatusId { get; set; }
        public string StatusTitle { get; set; }
        public string Color { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
