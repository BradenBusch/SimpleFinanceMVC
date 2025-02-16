using Microsoft.AspNetCore.Mvc;
using SimpleFinance.Data;
using SimpleFinance.Interfaces;
using SimpleFinance.Models;
using SimpleFinance.ViewModels;
using System.Threading.Tasks;

namespace SimpleFinance.Controllers
{
    public class AccountHeaderController(IAccountHeaderRepository accountHeaderRepository, DataContext context) : Controller
    {
        private readonly IAccountHeaderRepository _accountHeaderRepository = accountHeaderRepository;
        private readonly DataContext _context = context;

        // View for home page
        public async Task<IActionResult> AccountHome()
        {
            var accountHeaders = await _accountHeaderRepository.GetAccountHeaders();
            var accountHomeViewModel = new AccountHomeViewModel(accountHeaders);
            return View(accountHomeViewModel);
        }
        
        // View for adding an account
        public IActionResult AddAccount()
        {
            return View();
        }

        // Save the newly created account
        public async Task<IActionResult> SaveAccount(AddAccountViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var account = new AccountHeader(vm);
                await _accountHeaderRepository.CreateAccountHeader(account);
                return RedirectToAction("AccountHome");
            }
            return Redirect("AddAccount");
        }

        // View for Account Header Details
        public async Task<IActionResult> AccountHeaderDetails(Guid accountHeaderId)
        {
            var account = await _accountHeaderRepository.GetAccountHeaderByAccountId(accountHeaderId);
            var vm = new AccountHeaderDetailsViewModel(account);
            return View(vm);
        }

        public async Task<IActionResult> UpdateAccountHeader(Guid accountHeaderId, string accountName, string accountType, string accountDescription)
        {
            var currentAccount = await _accountHeaderRepository.GetAccountHeaderByAccountId(accountHeaderId);
            var updatedAccount = new AccountHeader();
            updatedAccount.AccountHeaderId = accountHeaderId;
            updatedAccount.AccountValue = currentAccount.AccountValue;
            updatedAccount.AccountName = accountName;
            updatedAccount.AccountType = accountType;
            updatedAccount.AccountDescription = accountDescription;

            await _accountHeaderRepository.UpdateAccountHeader(updatedAccount);

            return RedirectToAction("AccountHome");

        }

        
    }
}
