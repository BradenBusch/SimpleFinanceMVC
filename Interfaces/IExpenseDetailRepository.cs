using SimpleFinance.Models;

namespace SimpleFinance.Interfaces
{
    public interface IExpenseDetailRepository
    {
        Task<List<ExpenseDetail>> GetExpenseDetailsByHeaderId(Guid expenseHeaderId);
    }
}
