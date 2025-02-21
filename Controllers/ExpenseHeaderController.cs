using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using SimpleFinance.Data;
using SimpleFinance.Interfaces;
using SimpleFinance.Models;
using SimpleFinance.Repository;
using SimpleFinance.ViewModels;

namespace SimpleFinance.Controllers
{
    public class ExpenseHeaderController(IExpenseHeaderRepository expenseHeaderRepository) : Controller
    {
        private readonly IExpenseHeaderRepository _expenseHeaderRepository = expenseHeaderRepository;

        public IActionResult ExpenseHome()
        {
            return View();
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
    }
}
