using SimpleFinance.Models;

namespace SimpleFinance.Interfaces
{
    public interface IExpenseDetailRepository
    {
        Task<ExpenseDetail> CreateExpenseDetail(ExpenseDetail expenseDetail);
        Task<List<ExpenseDetail>> GetExpenseDetailsByHeaderId(Guid expenseHeaderId);
    }
}
