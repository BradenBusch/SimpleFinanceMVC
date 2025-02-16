using SimpleFinance.Models;

namespace SimpleFinance.Interfaces
{
    public interface IAccountDetailRepository
    {
        Task<List<AccountDetail>> GetAllAccountDetails();
        Task<List<AccountDetail>> GetAccountDetailsByHeaderId(Guid accountHeaderId);
        Task<AccountDetail> GetAccountDetail(Guid accountDetailId);
        Task<AccountDetail> CreateAccountDetail(AccountDetail accountDetail);
        Task<AccountDetail> DeleteAccountDetail(Guid accountDetailId);
        Task<AccountDetail> UpdateAccountDetail(AccountDetail accountDetail);
    }
}
