using System.Collections.Generic;
using TMD.Web.Models;

namespace TMD.Web.ViewModels
{
    public class EventViewModel
    {
        public EventViewModel()
        {
            this.EventModel=new EventModel();
            Companies = new List<Company>();
        }
        public EventModel EventModel { get; set; }
        public IEnumerable<Company> Companies { get; set; }
    }
}