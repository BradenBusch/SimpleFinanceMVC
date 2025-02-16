using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SimpleFinance.Models;

namespace SimpleFinance.ViewModels
{
    public class AddAccountDetailViewModel
    {
        public AddAccountDetailViewModel()
        {

        }
        public AddAccountDetailViewModel(AccountHeader accountHeader, List<AccountDetail> accountDetails)
        {
            AccountHeader = accountHeader;
            AccountHeaderId = accountHeader.AccountHeaderId;
            AccountDetails = accountDetails;
        }
        // ====================================
        // For Submitting To Save in Controller
        // ====================================
        [Required]
        [Display(Name = "New Account Value")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal AccountValue { get; set; }

        public Guid AccountHeaderId { get; set; }

        
        // ===============
        // UI View Objects
        // ===============
        public AccountHeader AccountHeader { get; set; }
        public List<AccountDetail> AccountDetails { get; set; }
    }
}
