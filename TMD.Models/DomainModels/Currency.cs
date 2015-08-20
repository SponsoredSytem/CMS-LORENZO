using System.Collections.Generic;

namespace TMD.Models.DomainModels
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencySymbol { get; set; }
        public string Description { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

        public double ExchangeRate { get; set; }
        public bool IsBaseCurrency { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
