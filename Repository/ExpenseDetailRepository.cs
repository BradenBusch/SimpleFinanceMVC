﻿using Microsoft.EntityFrameworkCore;
using SimpleFinance.Data;
using SimpleFinance.Interfaces;
using SimpleFinance.Models;

namespace SimpleFinance.Repository
{
    public class ExpenseDetailRepository : IExpenseDetailRepository
    {
        private readonly DataContext _context;

        public ExpenseDetailRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ExpenseDetail>> GetExpenseDetailsByHeaderId(Guid expenseHeaderId)
        {
            return await _context.ExpenseDetail.Where(ed => ed.ExpenseHeaderId == expenseHeaderId).ToListAsync();
        }
    }
}
