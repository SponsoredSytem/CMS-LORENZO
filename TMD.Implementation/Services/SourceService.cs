using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class SourceService : ISourceService
    {
        private readonly ISourceRepository sourceRepository;

        public SourceService(ISourceRepository sourceRepository)
        {
            this.sourceRepository = sourceRepository;
        }

        public Source GetSource(long sourceId)
        {
            return sourceRepository.Find(sourceId);
        }

        public IEnumerable<Source> GetAllSources()
        {
            return sourceRepository.GetAll();
        }

        public long SaveSource(Source source)
        {
            sourceRepository.Add(source);
            sourceRepository.SaveChanges();
            return source.SourceId;
        }
    }
}

