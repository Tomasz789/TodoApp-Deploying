using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.CurrencyHelper.Services;

namespace TodoApp.Testing.ApiTests
{
    [TestFixture]
    public class CurrencyExchangeTests
    {
        private ICurrencyExchangeService currencyExchangeService;

        [SetUp]
        public void Init()
        {
            currencyExchangeService = new CurrencyExchangeService();
        }

        [Test]
        public void ExchangeApiForEur_Test()
        {
            var result = currencyExchangeService.GetCurrentCurrencyValueForPLN("EUR").Result;
            bool isInRange = false;

            if (result >= 4.6m && result <= 4.85m)
            {
                isInRange = true;
            }

            Assert.IsNotNull(result);
            Assert.IsTrue(isInRange);

        }

        [Test]
        public void ExchangeApiForUSD_Test()
        {
            var result = currencyExchangeService.GetCurrentCurrencyValueForPLN("EUR").Result;
            bool isInRange = false;

            if (result >= 3.9m && result <= 4.99m)
            {
                isInRange = true;
            }

            Assert.IsNotNull(result);
            Assert.IsTrue(isInRange);

        }

        [Test]
        public void ExchangeApiForGBP_Test()
        {
            var result = currencyExchangeService.GetCurrentCurrencyValueForPLN("EUR").Result;
            bool isInRange = false;

            if (result >= 3.5m && result <= 6m)
            {
                isInRange = true;
            }

            Assert.IsNotNull(result);
            Assert.IsTrue(isInRange);

        }

        [Test]
        public void ExchangeApiThrowsInvalidOperationException_Test()
        {
            var res = currencyExchangeService.GetCurrentCurrencyValueForPLN("XYZ").Result;

            Assert.AreEqual(0m, res);
        }
    }
}
