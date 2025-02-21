using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleFinance.Models
{
    public class ExpenseHeader
    {
        public ExpenseHeader()
        {

        }

        public ExpenseHeader(AddExpenseViewModel vm)
        {
            ExpenseHeaderId = Guid.NewGuid();
            ExpenseValue = vm.ExpenseValue;
            ExpenseType = vm.ExpenseType;
            ExpenseName = vm.ExpenseName;
        }

        [Key]
        public Guid ExpenseHeaderId { get; set; }

        [Display(Name = "Value")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ExpenseValue { get; set; }

        [Display(Name = "Expense Type: ")]
        public string ExpenseType { get; set; }

        [Display(Name = "Expense Name")]
        public string ExpenseName { get; set; }
    }
}
