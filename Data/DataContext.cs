using Microsoft.EntityFrameworkCore;
using SimpleFinance.Controllers;
using SimpleFinance.Models;
using System.Collections.Generic;

namespace SimpleFinance.Data
{
    public class DataContext : DbContext
    {
        public IConfiguration _config { get; set; }
        public DataContext(IConfiguration config, DbContextOptions<DataContext> options) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        }

        public DbSet<AccountHeader> AccountHeader { get; set; }
        public DbSet<AccountDetail> AccountDetail { get; set; }
        public DbSet<ExpenseHeader> ExpenseHeader { get; set; }
        public DbSet<ExpenseDetail> ExpenseDetail { get; set; }
    }
}
