using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities.Budgets;
using TodoApp.Interop.Services.DataSheetModels;
using TodoApp.Interop.Services.DatasheetServices;

namespace TodoApp.Testing.InteropTests
{
    [TestFixture]
    public class ExcelSheetTests
    {
        private BudgetDataSheet bService;
        private readonly string[] messages = new string[2] {
            "No incomes found, cannot create a sheet.",
            "No expenses found, cannot create a sheet."
        };

        [SetUp]
        public void Init()
        {
            bService = new BudgetDataSheet();
            bService.AppVisible = true;
        }

        [Test]
        
        public void SheetService_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => bService.GenerateXslxFile(null));
        }

        [Test]

        public void SheetService_SetInfoMsg_And_ReturnsValueForEmptyIncomes()
        {
            var budget = new BudgetModel()
            {
                Title = "Budget 1",
                Incomes = new List<Income>() { },
                Expenses = new List<Expense>() { new Expense() { Id = 1, Name = "Exp 1", ExpenseValue = 20m, ExpenseCurrency = Currency.PLN } },
            };

            var result = bService.GenerateXslxFile(budget);
            var infoMsg = bService.InfoMsg;

            Assert.AreEqual(-1, result);
            Assert.AreEqual(messages[0], infoMsg);
        }

        [Test]
        public void SheetService_SetInfoMsg_And_ReturnsValueForEmptyExpenses()
        {
            var budget = new BudgetModel()
            {
                Title = "Budget 1",
                Incomes = new List<Income>() { new Income() { Id = 1, Name = "Inc 1", IncomeValue = 20m, IncomeCurrency = Currency.PLN } },
                Expenses = new List<Expense>() { },
            };

            var result = bService.GenerateXslxFile(budget);
            var infoMsg = bService.InfoMsg;

            Assert.AreEqual(-1, result);
            Assert.AreEqual(messages[1], infoMsg);
        }

        [Test]
        public void SheetService_CreateValidSheet()
        {
            var incomes = new List<Income>()
            {
                new Income() { Id = 1, CreatedAt = DateTime.Now.AddDays(-2), Name = "Inc1", IncomeValue = 200m },
                new Income() { Id = 2, IncomeValue = 300m, Name = "Inc2", CreatedAt = DateTime.Now.AddDays(-1)},
                new Income() { Id = 3, CreatedAt= DateTime.Now.AddDays(-2), Name = "Inc3", IncomeValue = 50m}
            };

            var expenses = new List<Expense>() 
            {
                new Expense() {Id = 1, Name = "Exp1", CreatedAt = DateTime.Now, DueDate = DateTime.Now.AddDays(2), ExpenseValue = 200m},
                new Expense() {Id = 2, Name = "Exp2", CreatedAt = DateTime.Now, DueDate = DateTime.Now.AddDays(-2), ExpenseValue = 20m},
                new Expense() {Id = 3, Name = "Exp3", CreatedAt = DateTime.Now, DueDate = DateTime.Now.AddDays(8), ExpenseValue = 10m},
            };

            var budget = new BudgetModel()
            {
                Title = "Nov 22",
                Expenses = expenses,
                Incomes = incomes,
            };

            bService.AppVisible = true;
            var res = bService.GenerateXslxFile(budget);

            Assert.AreEqual(1, res);
        }
    }
}
