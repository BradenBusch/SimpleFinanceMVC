using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleFinance.Models
{
    public class AccountHeader
    {
        public AccountHeader()
        {

        }

        public AccountHeader(AddAccountViewModel vm)
        {
            AccountHeaderId = Guid.NewGuid();
            AccountValue = vm.AccountValue;
            AccountType = vm.AccountType;
            AccountName = vm.AccountName;
            AccountDescription = vm.AccountDescription;
        }

        [Key]
        public Guid AccountHeaderId { get; set; }

        [Display(Name = "Value")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal AccountValue { get; set; }

        [Display(Name = "Account Type: ")]
        public string AccountType { get; set; } = string.Empty;

        [Display(Name = "Account Name: ")]
        public string AccountName { get; set; } = string.Empty;

        [Display(Name = "Account Description: ")]
        public string? AccountDescription { get; set; } = string.Empty;
    }
}
