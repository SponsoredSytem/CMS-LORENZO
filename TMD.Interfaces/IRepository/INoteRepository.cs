using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface INoteRepository : IBaseRepository<Note, long>
    {
        void DeleteAllNotesById(List<long> contactIds);
        IEnumerable<Note> GetNotesByCompanyId(long companyId);
    }
}
