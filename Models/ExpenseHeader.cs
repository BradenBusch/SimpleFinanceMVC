using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleFinance.Models
{
    public class ExpenseHeader
    {
        public ExpenseHeader()
        {

        }

        [Key]
        public Guid ExpenseHeaderId { get; set; }

        [Display(Name = "Value")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ExpenseValue { get; set; }

        [Display(Name = "Expense Type: ")]
        public string ExpenseType { get; set; }
    }
}
