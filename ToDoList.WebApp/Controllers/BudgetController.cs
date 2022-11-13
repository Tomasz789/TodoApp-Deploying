﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Todo.Domain.Entities.Budgets;
using TodoApp.CurrencyHelper.Services;
using TodoApp.DAL.Wrappers;
using TodoApp.Interop.Services.DataSheetModels;
using TodoApp.Interop.Services.DatasheetServices;
using TodoApp.WeatherApiHelper.Services;
using ToDoList.WebApp.Models.ViewModels.BudgetViewModels;

namespace ToDoList.WebApp.Controllers
{
    public class BudgetController : Controller
    {
        private readonly IRepositoryWrapper repo;
        private readonly ICurrencyExchangeService currencyService;
        private readonly IHttpClientFactory clientFactor;
        private readonly UserIpAddressApiHelper userIpAddressApiHelper;
        private readonly WeatherApiHelper weatherApiHelper;
        private readonly BudgetDataSheet sheetService;
        public BudgetController(IRepositoryWrapper repo, IHttpClientFactory clientFactory, WeatherApiHelper weatherApiHelper, UserIpAddressApiHelper helper, BudgetDataSheet sheetService)
        {
            this.repo = repo;
            this.clientFactor = clientFactory;
            userIpAddressApiHelper = helper;
            this.weatherApiHelper = weatherApiHelper;
            currencyService = new CurrencyExchangeService();
            this.sheetService = sheetService;
        }

        public async Task<IActionResult> Index()
        {
            var expenses = repo.ExpenseRepository.GetAll();
            var incomes = repo.IncomeRepository.GetAll();
            var loc = await userIpAddressApiHelper.GetResponseAsync();
            weatherApiHelper.UserCity = loc.City;
            var weather = await weatherApiHelper.GetResponseAsync();
            Console.WriteLine(weather.Current.Temp_C);

            var model = new BudgetSummaryViewModel()
            {
                TotalExpenses = expenses.Sum(x => x.ExpenseValue),
                TotalIncomes = incomes.Sum(x => x.IncomeValue),
                Incomes = incomes.ToList(),
                Expenses = expenses.ToList(),
                TotalExpensesCurrentWeek = expenses.Where(x => x.CreatedAt <= DateTime.Now.AddDays(-7)).Sum(x => x.ExpenseValue),
                TotalIncomesCurrentWeek = incomes.Where(x => x.CreatedAt <= DateTime.Now.AddDays(-7)).Sum(x => x.IncomeValue),
                TotalExpensesCurrentMonth = expenses.Where(x => x.CreatedAt <= DateTime.Now.AddMonths(-1)).Sum(x => x.ExpenseValue),
                TotalIncomesCurrentMonth = incomes.Where(x => x.CreatedAt <= DateTime.Now.AddMonths(-2)).Sum(x => x.IncomeValue),
                TotalExpensesCurrentYear = expenses.Where(x => x.CreatedAt <= DateTime.Now.AddYears(-1)).Sum(x => x.ExpenseValue),
                TotalIncomesCurrentYear = incomes.Where(x => x.CreatedAt <= DateTime.Now.AddYears(-1)).Sum(x => x.IncomeValue),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddIncome(IncomeViewModel vm)
        {
            var UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var incomeValue = vm.Value;

            if (ModelState.IsValid)
            {
                if (vm.Currency != Currency.PLN)
                {
                    incomeValue *= await currencyService.GetCurrentCurrencyValueForPLN(vm.Currency.ToString());
                }

                repo.IncomeRepository.Create(new Income()
                {
                    Name = vm.Name,
                    IncomeValue = incomeValue,
                    IncomeCurrency = vm.Currency,
                    CreatedAt = DateTime.Now,
                    UserId = UserId
                });
                repo.Save();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(ExpenseViewModel vm)
        {
            var UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var expenseValue = vm.Value;

            if (ModelState.IsValid)
            {
                if (vm.Currency != Currency.PLN)
                {
                    expenseValue *= await currencyService.GetCurrentCurrencyValueForPLN(vm.Currency.ToString());
                }

                repo.ExpenseRepository.Create(new Expense()
                {
                    Name = vm.Name,
                    ExpenseValue = expenseValue,
                    ExpenseCurrency = vm.Currency,
                    CreatedAt = DateTime.Now,
                    UserId = UserId,
                    DueDate = vm.DueDate,
                    PhotoPath = vm.PhotoPath,
                });

                repo.Save();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Report()
        {
            var budget = new BudgetModel()
            {
                Expenses = repo.ExpenseRepository.GetAll().Where(e => e.CreatedAt <= DateTime.Now.AddDays(-28)),
                Incomes = repo.IncomeRepository.GetAll().Where(i => i.CreatedAt <= DateTime.Now.AddDays(-28)),
                Title = $"Budget summary for {DateTime.Now.Month} / {DateTime.Now.Year}"
            };

            sheetService.GenerateXslxFile(budget);
            return RedirectToAction("Index");
        }
    }
}
