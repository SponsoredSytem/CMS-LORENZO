using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class CurrencyMapper
    {
        public static CurrencyModel CreateFromServerToClient(this Currency currency)
        {
            return new CurrencyModel
            {
                CurrencyId = currency.CurrencyId,
                CurrencyCode = currency.CurrencyCode,
                CurrencySymbol = currency.CurrencySymbol,
                Description = currency.Description,
                RecCreatedBy = currency.RecCreatedBy,
                RecCreatedDate = currency.RecCreatedDate,
                RecLastUpdatedBy = currency.RecLastUpdatedBy,
                RecLastUpdatedDate = currency.RecLastUpdatedDate
            };
        }
        public static Currency CreateFromClientToServer(this CurrencyModel currency)
        {
            return new Currency
            {
                CurrencyId = currency.CurrencyId,
                CurrencyCode = currency.CurrencyCode,
                CurrencySymbol = currency.CurrencySymbol,
                Description = currency.Description,
                RecCreatedBy = currency.RecCreatedBy,
                RecCreatedDate = currency.RecCreatedDate,
                RecLastUpdatedBy = currency.RecLastUpdatedBy,
                RecLastUpdatedDate = currency.RecLastUpdatedDate
            };
        }
    }
}