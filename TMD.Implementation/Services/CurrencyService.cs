using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class CurrencyService:ICurrencyService
    {
        private readonly ICurrencyRepository currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        public Currency GetCurrency(int currencyId)
        {
            return currencyRepository.Find(currencyId);
        }

        public IEnumerable<Currency> GetAllCurrencies()
        {
            return currencyRepository.GetAll();
        }

        public long SaveCurrency(Currency currency)
        {
            currencyRepository.Update(currency);
            currencyRepository.SaveChanges();
            return currency.CurrencyId;
        }

        public bool DeleteCurrency(Currency currency)
        {
            currencyRepository.Delete(currency);
            currencyRepository.SaveChanges();
            return true;
        }
    }
}
