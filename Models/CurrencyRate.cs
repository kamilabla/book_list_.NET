using System;
using System.Collections.Generic;

namespace BookManager.Models
{
    public class CurrencyRate
    {
        public string Code { get; set; }
        public string Currency { get; set; }
        public List<Rate> Rates { get; set; }
    }

    public class Rate
    {
        public string No { get; set; }
        public DateTime EffectiveDate { get; set; }
        public decimal Mid { get; set; }
    }
}
