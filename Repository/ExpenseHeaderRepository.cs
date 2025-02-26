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

        public async Task<ExpenseHeader> CreateExpenseHeader(ExpenseHeader expenseHeader)
        {
            await _context.ExpenseHeader.AddAsync(expenseHeader);
            var expenseDetail = new ExpenseDetail(expenseHeader);
            await _context.ExpenseDetail.AddAsync(expenseDetail);

            await _context.SaveChangesAsync();
            return expenseHeader;
        }

        public async Task<List<ExpenseHeader>> GetExpenseHeaders()
        {
            return await _context.ExpenseHeader.ToListAsync();
        }

        public async Task<ExpenseHeader> GetExpenseHeaderByExpenseHeaderId(Guid expenseHeaderId)
        {
            return await _context.ExpenseHeader.Where(eh => eh.ExpenseHeaderId == expenseHeaderId).FirstAsync();
        }
    }
}
