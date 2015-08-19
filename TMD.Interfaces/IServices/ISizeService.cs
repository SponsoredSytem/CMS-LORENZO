using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface ISizeService
    {
        Size GetSize(int sizeId);
        IEnumerable<Size> GetAllSizes();
        long SaveSize(Size size);
        bool DeleteSize(Size size);
    }
}
