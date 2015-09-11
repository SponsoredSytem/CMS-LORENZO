namespace TMD.Web.Models
{
    public class NoteModel
    {
        public long Id { get; set; }
        public System.DateTime NotesDate { get; set; }
        public long NotesCategoryId { get; set; }
        public string NotesCategoryName { get; set; }
        public string Description { get; set; }
        public System.DateTime ReminderDate { get; set; }
        public long? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
    }
}