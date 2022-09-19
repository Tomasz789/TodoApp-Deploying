using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.CurrencyHelper.Models
{
    [Serializable]
    public class Rate
    {
        public string No { get; set; }

        public string EffectiveDate { get; set; }

        public decimal Mid { get; set; }
    }
}
