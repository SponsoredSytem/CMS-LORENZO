using System;
using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class SizeService:ISizeService
    {
        private readonly ISizeRepository sizeRepository;

        public SizeService(ISizeRepository sizeRepository)
        {
            this.sizeRepository = sizeRepository;
        }

        public Size GetSize(int sizeId)
        {
            return sizeRepository.Find(sizeId);
        }

        public IEnumerable<Size> GetAllSizes()
        {
            return sizeRepository.GetAll();
        }

        public long SaveSize(Size size)
        {
            sizeRepository.Update(size);
            sizeRepository.SaveChanges();
            return size.SizeId;
        }

        public bool DeleteSize(Size size)
        {
            sizeRepository.Delete(size);
            sizeRepository.SaveChanges();
            return true;
        }
    }
}
