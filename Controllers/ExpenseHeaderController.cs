using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using SimpleFinance.Data;
using SimpleFinance.Interfaces;
using SimpleFinance.Migrations;
using SimpleFinance.Models;
using SimpleFinance.Repository;
using SimpleFinance.ViewModels;
using System.Threading.Tasks;

namespace SimpleFinance.Controllers
{
    public class ExpenseHeaderController(IExpenseHeaderRepository expenseHeaderRepository, IExpenseDetailRepository expenseDetailRepository) : Controller
    {
        private readonly IExpenseHeaderRepository _expenseHeaderRepository = expenseHeaderRepository;
        private readonly IExpenseDetailRepository _expenseDetailRepository = expenseDetailRepository;
        public async Task<IActionResult> ExpenseHome()
        {
            Dictionary<ExpenseHeader, List<ExpenseDetail>> mapping = new Dictionary<ExpenseHeader, List<ExpenseDetail>>();
            var expenseHeaders = await _expenseHeaderRepository.GetExpenseHeaders();
            foreach (var expenseHeader in expenseHeaders)
            {
                var expenseDetails = await _expenseDetailRepository.GetExpenseDetailsByHeaderId(expenseHeader.ExpenseHeaderId);
                mapping.Add(expenseHeader, new List<ExpenseDetail>());
                mapping[expenseHeader] = expenseDetails;
            }
            var vm = new ExpenseHomeViewModel(mapping);
            return View(vm);
        }

        public IActionResult AddExpense()
        {
            return View();
        }

        public async Task<IActionResult> CreateExpense(AddExpenseViewModel vm)
        {
            var expenseHeader = new ExpenseHeader(vm);
            await _expenseHeaderRepository.CreateExpenseHeader(expenseHeader);
            return RedirectToAction("ExpenseHome");
        }

        [HttpGet]
        public async Task<JsonResult> GetExpenseHeaderData(Guid expenseHeaderId)
        {
            var expenseHeader = await _expenseHeaderRepository.GetExpenseHeaderByExpenseHeaderId(expenseHeaderId);

            return Json(new
            {
                ExpenseHeaderId = expenseHeaderId,
                ExpenseType = expenseHeader.ExpenseType,
                ExpenseName = expenseHeader.ExpenseName
            });
        }
    }
}
