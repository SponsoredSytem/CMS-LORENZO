using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface ICurrencyService
    {
        Currency GetCurrency(int currencyId);
        IEnumerable<Currency> GetAllCurrencies();
        long SaveCurrency(Currency currency);

        bool DeleteCurrency(Currency currency);
    }
}
