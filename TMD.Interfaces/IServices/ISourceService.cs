using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface ISourceService
    {
        Source GetSource(long sourceId);
        IEnumerable<Source> GetAllSources();
        long SaveSource(Source source);
        bool DeleteSource(Source source);
    }
}
