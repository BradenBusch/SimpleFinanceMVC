using Microsoft.EntityFrameworkCore;
using SimpleFinance.Data;
using SimpleFinance.Interfaces;
using SimpleFinance.Models;

namespace SimpleFinance.Repository
{
    public class ExpenseHeaderRepository : IExpenseHeaderRepository
    {
        private readonly DataContext _context;

        public ExpenseHeaderRepository(DataContext context)
        {
            _context = context;
        }
    }
}
