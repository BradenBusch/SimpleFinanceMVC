using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleFinance.Models
{
    public class AddExpenseViewModel
    {
        [Required]
        [Display(Name = "Expense Cost")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ExpenseValue { get; set; }

        [Required]
        [Display(Name = "Expense Type")]
        public string ExpenseType { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Expense Name")]
        public string ExpenseName { get; set; } = string.Empty;
    }
}