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

        public IActionResult Index()
        {
            return View();
        }
    }
}
