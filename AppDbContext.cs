using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Homework4
{
    // here, we extend the DbContext class with our own class 'AppDbContect'
    public class AppDbContext : DbContext
    {
        //The connection string is used by the SQL Server database provider to find the database
        private const string ConnectionString = @"Data Source=MyFirstEfCoreDb.db";
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            //Using the SQLite database provider’s UseSqlServer command sets up the options ready for creating the applications’s DBContext
            optionsBuilder.UseSqlite(ConnectionString); //#B
        }

        public DbSet<Client> Clients {get; set;}
        public DbSet<Student> Students {get; set;}

        public DbSet<Team> Teams {get; set;}

        public DbSet<Organization> Organizations {get; set;} 
    }
}            