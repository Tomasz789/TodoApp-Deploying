using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.CurrencyHelper.Services
{
    public interface ICurrencyExchangeService
    {
        Task<decimal> GetCurrentCurrencyValueForPLN(string currency);
    }
}
