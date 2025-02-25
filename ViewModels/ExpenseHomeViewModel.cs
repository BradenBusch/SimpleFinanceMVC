using Microsoft.Identity.Client;
using SimpleFinance.Models;

namespace SimpleFinance.ViewModels
{
    public class ExpenseHomeViewModel
    {
        public ExpenseHomeViewModel(Dictionary<ExpenseHeader, List<ExpenseDetail>> expenses)
        {
            Expenses = expenses;
            AssignValues();
        }

        public Dictionary<ExpenseHeader, List<ExpenseDetail>> Expenses { get; set; }
        public Dictionary<Guid, string> DateDisplay { get; set;}
        public decimal TotalExpenses { get; set; }

        public void AssignValues ()
        {
            DateDisplay = new Dictionary<Guid, string>();
            foreach (var expense in Expenses)
            {
                var lastDate = expense.Value.Last().CreateDate;
                var firstDate = expense.Value.First().CreateDate;
                string display = string.Empty;
                if (!lastDate.Equals(firstDate))
                {
                    display = firstDate.ToShortDateString() + " - " + lastDate.ToShortDateString();
                }
                else
                {
                    display = firstDate.ToShortDateString();
                }
                DateDisplay.Add(expense.Key.ExpenseHeaderId, display);
            }
        }
    }
}
