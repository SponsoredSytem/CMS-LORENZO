using System;
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

            if (source.SourceId > 0)
                sourceRepository.Update(source);
            else
                sourceRepository.Add(source);
            sourceRepository.SaveChanges();
            return source.SourceId;

            //sourceRepository.Add(source);
            //sourceRepository.SaveChanges();
            //return source.SourceId;
        }

        public bool DeleteSource(Source source)
        {
            try
            {
                sourceRepository.Delete(source);
                sourceRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}

