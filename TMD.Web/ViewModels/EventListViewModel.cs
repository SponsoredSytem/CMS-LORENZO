using System.Collections.Generic;
using TMD.Web.Models;

namespace TMD.Web.ViewModels
{
    public class EventListViewModel
    {
        public EventListViewModel()
        {
            Events = new List<EventModel>();
            Companies = new List<Company>();
        }
        public IEnumerable<EventModel> Events { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public int TodaysEvents { get; set; }
        public int TomorrowsEvents { get; set; }
    }
}