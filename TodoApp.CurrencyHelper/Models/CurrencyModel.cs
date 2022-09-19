using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.CurrencyHelper.Models
{
    [Serializable]
    public class CurrencyModel
    {
        public string Table { get; set; }

        public string Currency { get; set; }

        public string Code { get; set; }

        public Rate[] Rates { get; set; }
    }
}
