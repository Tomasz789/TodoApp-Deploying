using System.ComponentModel.DataAnnotations;
using Todo.Domain.Entities.Budgets;

namespace ToDoList.WebApp.Models.ViewModels.BudgetViewModels
{
    public class IncomeViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public Currency Currency { get; set; }


    }
}
