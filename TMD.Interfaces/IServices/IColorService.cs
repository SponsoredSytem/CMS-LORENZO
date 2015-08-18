using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IColorService
    {
        Color GetColor(int colorId);
        IEnumerable<Color> GetAllColors();
        long SaveColor(Color color);

        bool DeleteColor(Color color);
    }
}
