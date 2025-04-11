using System;

namespace BookManager.Models
{
    public class CurrencyRateEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }      //  "USD"
        public string Currency { get; set; }  // "dolar amerykański"
        public string RateNo { get; set; }    // "065/A/NBP/2024"
        public DateTime EffectiveDate { get; set; }
        public decimal Mid { get; set; }
    }
}
