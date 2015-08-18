using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface ISizeService
    {
        Size GetSize(int sizeId);
        IEnumerable<Size> GetAllColors();
        long SaveColor(Size size);
        bool DeleteColor(Size size);
    }
}
