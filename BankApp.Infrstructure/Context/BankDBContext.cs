using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Domain;
using BankApp.Infrastructure.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BankApp.Infrastructure.Context
{
    internal class BankDBContext:DbContext
    {
        public BankDBContext(DbContextOptions<BankDBContext>options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new AccountsConfiguration());
            //modelBuilder.ApplyConfiguration(new TransactionsConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Accounts> Account { get; set; }
        public DbSet<Transactions> Transaction { get; set; }

    }
}
