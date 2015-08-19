using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class ColorService:IColorService
    {
        private readonly IColorRepository colorRepository;

        public ColorService(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }

        public Color GetColor(int colorId)
        {
            return colorRepository.Find(colorId);
        }

        public IEnumerable<Color> GetAllColors()
        {
            return colorRepository.GetAll();
        }

        public long SaveColor(Color color)
        {
            colorRepository.Update(color);
            colorRepository.SaveChanges();
            return color.ColorId;
        }

        public bool DeleteColor(Color color)
        {
            colorRepository.Delete(color);
            colorRepository.SaveChanges();
            return true;
        }
    }
}
