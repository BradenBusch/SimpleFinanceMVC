using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using SimpleFinance.Data;
using SimpleFinance.Interfaces;
using SimpleFinance.Models;
using SimpleFinance.Repository;
using SimpleFinance.ViewModels;
namespace SimpleFinance.Controllers
{
    public class AccountDetailController(IAccountHeaderRepository accountHeaderRepository, IAccountDetailRepository accountDetailRepository) : Controller
    {
        private readonly IAccountHeaderRepository _accountHeaderRepository = accountHeaderRepository;
        private readonly IAccountDetailRepository _accountDetailRepository = accountDetailRepository;

        // View for updating account balance
        public async Task<IActionResult> AccountDetails(Guid accountHeaderId)
        {
            var accountHeader = await _accountHeaderRepository.GetAccountHeaderByAccountId(accountHeaderId);
            var accountDetails = await _accountDetailRepository.GetAccountDetailsByHeaderId(accountHeaderId);
            AccountDetailsViewModel vm = new AccountDetailsViewModel(accountHeader, accountDetails);
            return View(vm);
        }

        // Save updated account balance. Update Account Header Value (this is what is 'top level' i.e. displayed as the most updated value. Could just get the most recent detail to do this, but it makes the value more accessible.)
        public async Task<IActionResult> SaveAccountDetail(AccountDetailsViewModel vm)
        {
            var accountDetail = new AccountDetail(vm);

            var accountHeader = await _accountHeaderRepository.GetAccountHeaderByAccountId(vm.AccountHeaderId);
            accountHeader.AccountValue = vm.AccountValue;

            await _accountDetailRepository.CreateAccountDetail(accountDetail);
            await _accountHeaderRepository.UpdateAccountHeader(accountHeader);
            
            return RedirectToAction("AccountDetails", new { accountHeaderId = vm.AccountHeaderId });
        }

        // Delete one account detail
        public async Task<IActionResult> DeleteAccountDetail(Guid accountDetailId, Guid accountHeaderId)
        {
            await _accountDetailRepository.DeleteAccountDetail(accountDetailId);
            return RedirectToAction("AccountDetails", new { accountHeaderId });
        }
    }
}
