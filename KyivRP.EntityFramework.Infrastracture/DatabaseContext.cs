using KyivRP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KyivRP.EntityFramework.Infrastracture
{
    public class DatabaseContext : DbContext
    {
        private readonly string _connectionString = "server=localhost;port=3306;database=kyivrp;uid=root;password=admin";

        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

            optionsBuilder.UseMySQL(_connectionString);
        }
    }
}
