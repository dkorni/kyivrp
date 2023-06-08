using KyivRP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KyivRP.EntityFramework.Infrastracture
{
    public class DatabaseContext : DbContext
    {
        private readonly string _connectionString = "Server=(LocalDb)\\MSSQLLocalDB;Database=kyivrp;Trusted_Connection=True;";

        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
