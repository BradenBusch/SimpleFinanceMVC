using SimpleFinance.Models;

namespace SimpleFinance.ViewModels
{
    public class AccountHomeViewModel
    {
        public AccountHomeViewModel(List<AccountHeader> accountHeaders)
        {
            Accounts = accountHeaders;
            NetWorth = GetNetWorth();
        }
        public List<AccountHeader> Accounts { get; set; } = new List<AccountHeader>();

        public decimal NetWorth { get; set; }

        public decimal GetNetWorth()
        {
            decimal totalValue = 0.00m;
            foreach (var account in Accounts)
            {
                totalValue += account.AccountValue;
            }
            return totalValue;
        }
    }
}
