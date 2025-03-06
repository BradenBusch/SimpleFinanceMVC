using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleFinance.Models
{
    public class ExpenseDetail
    {
        public ExpenseDetail()
        {
            
        }

       public ExpenseDetail(Guid expenseHeaderId, decimal expenseValue)  
        {
            ExpenseDetailId = Guid.NewGuid();
            ExpenseHeaderId = expenseHeaderId;
            ExpenseValue = expenseValue;
            CreateDate = DateTime.Now;
        }

        public ExpenseDetail(ExpenseHeader expenseHeader)
        {
            ExpenseDetailId = Guid.NewGuid();
            ExpenseHeaderId = expenseHeader.ExpenseHeaderId;
            ExpenseValue = expenseHeader.ExpenseValue;
            CreateDate = DateTime.Now;
        }

        [Key]
        public Guid ExpenseDetailId { get; set; }
        public Guid ExpenseHeaderId { get; set; }

        [Display(Name = "Value")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ExpenseValue { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
