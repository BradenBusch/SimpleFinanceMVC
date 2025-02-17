using SimpleFinance.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleFinance.Models
{
    public class AccountDetail
    {
        public AccountDetail()
        {

        }
        // Used when creating a new account
        public AccountDetail(AccountHeader ah)
        {
            AccountDetailId = Guid.NewGuid();
            AccountHeaderId = ah.AccountHeaderId;
            AccountValue = ah.AccountValue;
            CreateDate = DateTime.Now;
        }
        public AccountDetail(AccountDetailsViewModel vm)
        {
            AccountDetailId = Guid.NewGuid();
            AccountHeaderId = vm.AccountHeaderId;
            AccountValue = vm.AccountValue;
            CreateDate = DateTime.Now;
        }

        [Key]
        public Guid AccountDetailId { get; set; }
        public Guid AccountHeaderId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AccountValue { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
