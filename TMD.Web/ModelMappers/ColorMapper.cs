using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class ColorMapper
    {
        public static ColorModel CreateFromServerToClient(this Color color)
        {
            return new ColorModel
            {
                ColorId = color.ColorId,
                ColorTitle = color.ColorTitle,
                ColorValue = color.ColorValue,
                ColorDescription = color.ColorDescription,
                RecCreatedBy = color.RecCreatedBy,
                RecCreatedDate = color.RecCreatedDate,
                RecLastUpdatedBy = color.RecLastUpdatedBy,
                RecLastUpdatedDate = color.RecLastUpdatedDate
            };
        }

        public static Color CreateFromClientToServer(this ColorModel color)
        {
            return new Color
            {
                ColorId = color.ColorId,
                ColorTitle = color.ColorTitle,
                ColorValue = color.ColorValue,
                ColorDescription = color.ColorDescription,
                RecCreatedBy = color.RecCreatedBy,
                RecCreatedDate = color.RecCreatedDate,
                RecLastUpdatedBy = color.RecLastUpdatedBy,
                RecLastUpdatedDate = color.RecLastUpdatedDate
            };
        }
    }
}