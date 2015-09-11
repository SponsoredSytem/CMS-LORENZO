using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class NoteMapper
    {
        public static Note CreateFromClientToServer(this NoteModel source)
        {
            return new Note
            {
                Id = source.Id,
                NotesDate = source.NotesDate,
                ReminderDate = source.ReminderDate,
                NotesCategoryId = source.NotesCategoryId,
                CompanyId = source.CompanyId,
                Description = source.Description,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }

        public static NoteModel CreateFromServerToClient(this Note source)
        {
            return new NoteModel
            {
                Id = source.Id,
                NotesDate = source.NotesDate,
                ReminderDate = source.ReminderDate,
                NotesCategoryId = source.NotesCategoryId,
                NotesCategoryName = source.NotesCategory.Name,
                CompanyId = source.CompanyId,
                CompanyName = source.Company.CompanyName,
                Description = source.Description,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
    }
}