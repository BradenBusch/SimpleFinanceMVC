using Microsoft.EntityFrameworkCore;
using SimpleFinance.Data;
using SimpleFinance.Interfaces;
using SimpleFinance.Models;

namespace SimpleFinance.Repository
{
    public class AccountHeaderRepository : IAccountHeaderRepository
    {
        private readonly DataContext _context;

        public AccountHeaderRepository(DataContext context)
        {
            _context = context;
        }

        // Get All Accounts Regardless of User
        public async Task<List<AccountHeader>> GetAccountHeaders()
        {
            return await _context.AccountHeader.ToListAsync();
        }

        // Get An Account Header By Id
        public async Task<AccountHeader> GetAccountHeaderByAccountId(Guid accountHeaderId)
        {
            return await _context.AccountHeader.Where(x => x.AccountHeaderId == accountHeaderId).FirstAsync();
        }

        // Create an Account Header
        public async Task<AccountHeader> CreateAccountHeader(AccountHeader accountHeader)
        {
            await _context.AccountHeader.AddAsync(accountHeader);
            await _context.SaveChangesAsync();

            var accountDetail = new AccountDetail(accountHeader);
            await _context.AccountDetail.AddAsync(accountDetail);
            await _context.SaveChangesAsync();

            return accountHeader;
        }

        // Delete an Account Header
        public async Task<AccountHeader> DeleteAccountHeader(Guid accountHeaderId)
        {
            var accountHeader = await _context.AccountHeader.FirstOrDefaultAsync(x => x.AccountHeaderId == accountHeaderId);

            if (accountHeader == null)
            {
                return null;
            }

            _context.AccountHeader.Remove(accountHeader);
            await _context.SaveChangesAsync();
            return accountHeader;
        }

        // Update an Account Header
        public async Task<AccountHeader> UpdateAccountHeader(AccountHeader accountHeader)
        {
            var existingAccountHeader = await _context.AccountHeader.FirstOrDefaultAsync(x => x.AccountHeaderId == accountHeader.AccountHeaderId);

            if (existingAccountHeader == null)
            {
                return null;
            }

            existingAccountHeader.AccountDescription = accountHeader.AccountDescription;
            existingAccountHeader.AccountName = accountHeader.AccountName;
            existingAccountHeader.AccountValue = accountHeader.AccountValue;
            existingAccountHeader.AccountType = accountHeader.AccountType;

            await _context.SaveChangesAsync();
            return accountHeader;
        }
    }
}
