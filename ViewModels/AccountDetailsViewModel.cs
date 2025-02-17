using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SimpleFinance.Models;
using System.Globalization;

namespace SimpleFinance.ViewModels
{
    public class AccountDetailsViewModel
    {
        public AccountDetailsViewModel()
        {

        }
        public AccountDetailsViewModel(AccountHeader accountHeader, List<AccountDetail> accountDetails)
        {
            AccountHeader = accountHeader;
            AccountHeaderId = accountHeader.AccountHeaderId;
            AccountDetails = accountDetails;
            AccountAmountChange = CalculateAmountChange();
            AccountPercentageChange = CalculatePercentageChange();
        }
        // ====================================
        // For Submitting To Save in Controller
        // ====================================
        [Required]
        [Display(Name = "Account Value")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal AccountValue { get; set; }

        public Guid AccountHeaderId { get; set; }

        
        // ===============
        // UI View Objects
        // ===============
        public AccountHeader AccountHeader { get; set; }
        public List<AccountDetail> AccountDetails { get; set; }

        public string AccountPercentageChange { get; set; }

        public string AccountAmountChange { get; set; }

        public string CalculateAmountChange()
        {
            var newestDetail = AccountDetails.First();
            var oldestDetail = AccountDetails.Last();

            NumberFormatInfo currencyFormat = new CultureInfo(CultureInfo.CurrentCulture.ToString()).NumberFormat;
            currencyFormat.CurrencyNegativePattern = 1;
            return String.Format(currencyFormat, "{0:c}", (newestDetail.AccountValue - oldestDetail.AccountValue));
        }

        public string CalculatePercentageChange()
        {
            var newestDetail = AccountDetails.First();
            var oldestDetail = AccountDetails.Last();

            return ((newestDetail.AccountValue - oldestDetail.AccountValue) / oldestDetail.AccountValue).ToString("p");
        }
    }
}
