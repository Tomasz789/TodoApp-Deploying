using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Todo.Domain.Entities.Budgets;
using TodoApp.CurrencyHelper.Services;
using TodoApp.DAL.Wrappers;
using ToDoList.WebApp.Models.ViewModels.BudgetViewModels;

namespace ToDoList.WebApp.Controllers
{
    public class BudgetController : Controller
    {
        private readonly IRepositoryWrapper repo;
        private readonly ICurrencyExchangeService currencyService;
        public BudgetController(IRepositoryWrapper repo)
        {
            this.repo = repo;
            currencyService = new CurrencyExchangeService();
        }

        public async Task<IActionResult> Index()
        {
            var expenses = repo.ExpenseRepository.GetAll();
            var incomes = repo.IncomeRepository.GetAll();

            foreach (var expense in expenses)
            {
                if (expense.ExpenseCurrency != Currency.PLN)
                {
                    expense.ExpenseValue *= await currencyService.GetCurrentCurrencyValueForPLN(expense.ExpenseCurrency.ToString());
                }
            }

            foreach (var income in incomes)
            {
                if (income.IncomeCurrency != Currency.PLN)
                {
                    income.IncomeValue *= await currencyService.GetCurrentCurrencyValueForPLN(income.IncomeCurrency.ToString());
                }
            }
            var model = new BudgetSummaryViewModel()
            {
                TotalExpenses = expenses.Sum(x => x.ExpenseValue),
                TotalIncomes = incomes.Sum(x => x.IncomeValue),
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddIncome(IncomeViewModel vm)
        {
            var UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (ModelState.IsValid)
            {
                repo.IncomeRepository.Create(new Income()
                {
                    Name = vm.Name,
                    IncomeValue = vm.Value,
                    IncomeCurrency = vm.Currency,
                    CreatedAt = DateTime.Now,
                    UserId = UserId
                });
                repo.Save();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddExpense(ExpenseViewModel vm)
        {
            var UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (ModelState.IsValid)
            {
                repo.ExpenseRepository.Create(new Expense()
                {
                    Name = vm.Name,
                    ExpenseValue = vm.Value,
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
    }
}
