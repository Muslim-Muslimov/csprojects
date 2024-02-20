using System;
using CakesLibrary.Models;
using  Microsoft.EntityFrameworkCore;

namespace CakesLibrary
{
    public class MyDbContext : DbContext
    {
        public DbSet<Ingredient> _ingredients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = $"Data Source=F:\\c# projects\\csprojects\\CakesLibrary";
            optionsBuilder.UseSqlite(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
