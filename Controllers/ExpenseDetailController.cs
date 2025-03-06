using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using SimpleFinance.Data;
using SimpleFinance.Interfaces;
using SimpleFinance.Models;
using SimpleFinance.Repository;
using SimpleFinance.ViewModels;
using System.Threading.Tasks;

namespace SimpleFinance.Controllers
{
    public class ExpenseDetailController(IExpenseHeaderRepository expenseHeaderRepository, IExpenseDetailRepository expenseDetailRepository) : Controller
    {
        private readonly IExpenseHeaderRepository _expenseHeaderRepository = expenseHeaderRepository;
        private readonly IExpenseDetailRepository _expenseDetailRepository = expenseDetailRepository;

        public async Task<IActionResult> CreateExpenseDetail(Guid expenseHeaderId, decimal expenseValue)
        {
            var expenseHeader = await _expenseHeaderRepository.GetExpenseHeaderByExpenseHeaderId(expenseHeaderId);

            ExpenseDetail expenseDetail = new ExpenseDetail(expenseHeaderId, expenseValue);

            expenseHeader.ExpenseValue += expenseValue;

            await _expenseDetailRepository.CreateExpenseDetail(expenseDetail);
            await _expenseHeaderRepository.UpdateExpenseHeader(expenseHeader);
            return RedirectToAction("ExpenseHome", "ExpenseHeader");
        }


    }
}
