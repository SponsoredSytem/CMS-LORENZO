using System.ComponentModel.DataAnnotations;

namespace TMD.Web.Models
{
    public class CurrencyModel
    {
        public int CurrencyId { get; set; }
        [Display(Name = "Currency Code")]
        public string CurrencyCode { get; set; }
        [Display(Name = "Currency Symbol")]
        public string CurrencySymbol { get; set; }
        public string Description { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

        [Display(Name = "Exchange Rate")]
        public double ExchangeRate { get; set; }
        [Display(Name = "Is Base Currency?")]
        public bool IsBaseCurrency { get; set; }
    }
}