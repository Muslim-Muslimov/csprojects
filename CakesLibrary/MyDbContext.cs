using System;
using CakesLibrary.Models;
using  Microsoft.EntityFrameworkCore;

namespace CakesLibrary
{
    public class MyDbContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = $"Data Source=CakesLibrary.db";
            optionsBuilder.UseSqlite(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
