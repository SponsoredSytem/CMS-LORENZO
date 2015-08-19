using TMD.Web.Models;
using Size = TMD.Models.DomainModels.Size;

namespace TMD.Web.ModelMappers
{
    public static class SizeMapper
    {
        public static SizeModel CreateFromServerToClient(this Size size)
        {
            return new SizeModel
            {
                SizeId = size.SizeId,
                SizeTitle = size.SizeValue,
                SizeValue = size.SizeTitle,
                SizeDescription = size.SizeDescription,
                RecCreatedBy = size.RecCreatedBy,
                RecCreatedDate = size.RecCreatedDate,
                RecLastUpdatedBy = size.RecLastUpdatedBy,
                RecLastUpdatedDate = size.RecLastUpdatedDate
            };
        }

        public static Size CreateFromClientToServer(this SizeModel size)
        {
            return new Size
            {
                SizeId = size.SizeId,
                SizeTitle = size.SizeValue,
                SizeValue = size.SizeTitle,
                SizeDescription = size.SizeDescription,
                RecCreatedBy = size.RecCreatedBy,
                RecCreatedDate = size.RecCreatedDate,
                RecLastUpdatedBy = size.RecLastUpdatedBy,
                RecLastUpdatedDate = size.RecLastUpdatedDate
            };
        }
    }
}