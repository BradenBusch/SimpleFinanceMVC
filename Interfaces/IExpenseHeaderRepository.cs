using SimpleFinance.Models;

namespace SimpleFinance.Interfaces
{
    public interface IExpenseHeaderRepository
    {
        Task<ExpenseHeader> CreateExpenseHeader(ExpenseHeader expenseHeader);
        Task<List<ExpenseHeader>> GetExpenseHeaders();
        Task<ExpenseHeader> GetExpenseHeaderByExpenseHeaderId(Guid expenseHeaderId);

    }
}
