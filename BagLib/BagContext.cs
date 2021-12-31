using BagLib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagLib
{
    public partial class BagContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public DbSet<Market> Markets { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<MyStock> MyStocks { get; set; }

        public DbSet<BagUser> BagUsers { get; set; }


        public BagContext(DbContextOptions<BagContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
               // optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Bag;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer("Server=localhost\\SQLDEVELOPER;Database=Blog;Trusted_Connection=True;");
            }
        }
    }
}

