using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleFinance.Models
{
    public class AddAccountViewModel
    {
        [Required]
        [Display(Name = "Current Account Value")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal AccountValue { get; set; }

        [Required]
        [Display(Name = "Account Type")]
        public string AccountType { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Account Name")]
        public string AccountName { get; set; } = string.Empty;

        [Display(Name = "Account Description")]
        public string AccountDescription { get; set; } = string.Empty;
    }
}