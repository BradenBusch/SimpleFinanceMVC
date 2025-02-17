using Microsoft.EntityFrameworkCore;
using SimpleFinance.Data;
using SimpleFinance.Interfaces;
using SimpleFinance.Models;

namespace SimpleFinance.Repository
{
    public class AccountDetailRepository : IAccountDetailRepository
    {
        private readonly DataContext _context;

        public AccountDetailRepository(DataContext context)
        {
            _context = context;
        }

        // Get All Account Details
        public async Task<List<AccountDetail>> GetAllAccountDetails()
        {
            return await _context.AccountDetail.ToListAsync();
        }

        // Get Account Detail By Id (Singular -- use for displaying one detail entry)
        public async Task<AccountDetail> GetAccountDetail(Guid accountDetailId)
        {
            return await _context.AccountDetail.Where(ad => ad.AccountDetailId == accountDetailId).FirstAsync();
        }

        // Get Account Details By Header Id (Plural -- use for getting all details associated with one account)
        public async Task<List<AccountDetail>> GetAccountDetailsByHeaderId(Guid accountHeaderId)
        {
            return await _context.AccountDetail
                .Where(ad => ad.AccountHeaderId == accountHeaderId)
                .OrderByDescending(ad => ad.CreateDate)
                .ToListAsync();
        }

        // Create an Account Detail
        public async Task<AccountDetail> CreateAccountDetail(AccountDetail accountDetail)
        {   
            await _context.AccountDetail.AddAsync(accountDetail);
            await _context.SaveChangesAsync();
            return accountDetail;
        }

        // Update an Account Detail
        public async Task<AccountDetail> UpdateAccountDetail(AccountDetail accountDetail)
        {
            var existingAccountDetail = await _context.AccountDetail.FirstOrDefaultAsync(x => x.AccountDetailId == accountDetail.AccountDetailId);

            if (existingAccountDetail == null)
            {
                return null;
            }

            existingAccountDetail.AccountValue = accountDetail.AccountValue;

            await _context.SaveChangesAsync();
            return existingAccountDetail;
        }

        // Delete an Account Detail By Id
        public async Task<AccountDetail> DeleteAccountDetail(Guid accountDetailId)
        {
            var accountDetail = await _context.AccountDetail.FirstOrDefaultAsync(x => x.AccountDetailId == accountDetailId);

            if (accountDetail == null)
            {
                return null;
            }

            _context.AccountDetail.Remove(accountDetail);
            await _context.SaveChangesAsync();
            return accountDetail;
        }

        // Delete all details for an account
        public async Task DeleteAccountDetailsByHeaderId(Guid accountHeaderId)
        {
            var accountDetails = await _context.AccountDetail.Where(x => x.AccountHeaderId == accountHeaderId).ToListAsync();

            _context.AccountDetail.RemoveRange(accountDetails);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllAccountDetails()
        {
            //_context.Database.ExecuteSqlCommand("TRUNCATE TABLE "AccountDetail");
            await _context.AccountDetail.ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

    }
}
