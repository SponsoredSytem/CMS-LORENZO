using System.Collections.Generic;
using TMD.Web.Models;

namespace TMD.Web.ViewModels
{
    public class EventViewModel
    {
        public EventViewModel()
        {
            EventModel=new EventModel();
            Companies = new List<Company>();
            EventStatuses = new List<EventStatus>();
        }
        public EventModel EventModel { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<EventStatus> EventStatuses { get; set; }
    }
}