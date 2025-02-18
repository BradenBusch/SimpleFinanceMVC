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

        // View for Account Details
        public async Task<IActionResult> AccountDetails(Guid accountHeaderId)
        {
            var accountHeader = await _accountHeaderRepository.GetAccountHeaderByAccountId(accountHeaderId);
            var accountDetails = await _accountDetailRepository.GetAccountDetailsByHeaderId(accountHeaderId);
            AccountDetailsViewModel vm = new AccountDetailsViewModel(accountHeader, accountDetails);
            return View(vm);
        }

        // Create a new detail, and update Account Header Value to reflect new detail. 
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

            // If deleted detail was the newest detail, re-save Account Header
            var details = await _accountDetailRepository.GetAccountDetailsByHeaderId(accountHeaderId);
            var newestDetail = details
                .OrderByDescending(d => d.CreateDate)
                .First();

            var accountHeader = await _accountHeaderRepository.GetAccountHeaderByAccountId(accountHeaderId);
            accountHeader.AccountValue = newestDetail.AccountValue;
            await _accountHeaderRepository.UpdateAccountHeader(accountHeader);

            return RedirectToAction("AccountDetails", new { accountHeaderId });
        }
    }
}
