using System;
using System.ComponentModel.DataAnnotations;
using Todo.Domain.Entities.Budgets;

namespace ToDoList.WebApp.Models.ViewModels.BudgetViewModels
{
    public class ExpenseViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal Value { get; set; }

        public DateTime DueDate { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.Currency)]
        public Currency Currency { get; set; }

        public string PhotoPath { get; set; }
    }
}
