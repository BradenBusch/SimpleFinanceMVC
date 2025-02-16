using SimpleFinance.Models;

namespace SimpleFinance.ViewModels
{
    public class AccountHeaderDetailsViewModel
    {
        public AccountHeaderDetailsViewModel(AccountHeader accountHeader)
        {
            AccountHeader = accountHeader;
        }

        public AccountHeader AccountHeader { get; set; }

    }
}
