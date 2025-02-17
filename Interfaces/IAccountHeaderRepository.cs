using SimpleFinance.Models;

namespace SimpleFinance.Interfaces
{
    public interface IAccountHeaderRepository
    {
        Task<List<AccountHeader>> GetAccountHeaders();
        Task<AccountHeader> GetAccountHeaderByAccountId(Guid accountId);
        Task<AccountHeader> CreateAccountHeader(AccountHeader accountHeader);
        Task<AccountHeader> UpdateAccountHeader(AccountHeader accountHeader);
        Task<AccountHeader> DeleteAccountHeader(Guid accountHeader);
        Task DeleteAllAccountHeaders();
    }
}
