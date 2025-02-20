using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using SimpleFinance.Data;
using SimpleFinance.Interfaces;
using SimpleFinance.Models;
using SimpleFinance.Repository;
using SimpleFinance.ViewModels;

namespace SimpleFinance.Controllers
{
    public class ExpenseDetailController(IExpenseDetailRepository expenseDetailRepository) : Controller
    {
        private readonly IExpenseDetailRepository _expenseDetailRepository = expenseDetailRepository;

        public IActionResult Index()
        {
            return View();
        }
    }
}
