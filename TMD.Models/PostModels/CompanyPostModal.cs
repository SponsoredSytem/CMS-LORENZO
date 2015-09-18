using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Models.PostModels
{
    public class CompanyPostModal
    {
        public Company Company { get; set; }
        public IEnumerable<Note> CompanyNotes { get; set; }
        public IEnumerable<CompanyContact> CompanyContacts { get; set; }
        public string ContactsToBeDeleted { get; set; }
        public string NotesToBeDeleted { get; set; }
    }
}
