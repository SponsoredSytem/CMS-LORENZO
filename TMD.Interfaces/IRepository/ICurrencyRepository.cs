using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface ICurrencyRepository : IBaseRepository<Currency, int>
    {
        Currency GetBaseCurrency();
    }
}
