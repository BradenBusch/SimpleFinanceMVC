using SimpleFinance.Models;

namespace SimpleFinance.Interfaces
{
    public interface IExpenseHeaderRepository
    {
        Task<ExpenseHeader> CreateExpenseHeader(ExpenseHeader expenseHeader);
    }
}
