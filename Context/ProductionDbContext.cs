using adminPortal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminPortal.Context
{
    public class ProductionDbContext : DbContext
    {
        public ProductionDbContext(DbContextOptions<ProductionDbContext> options)
            : base(options)
        {
        }
        public DbSet<Pager> pager { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Authentication>();
            modelBuilder.Entity<Users>().HasNoKey();
            modelBuilder.Entity<Pager>().HasNoKey();
            //    modelBuilder
            //.Entity<Pager>(
            //    eb =>
            //    {
            //        eb.HasNoKey();
            //        eb.ToView("View_Dev");
            //        eb.Property(v => v.CurrentPageIndex).HasColumnName("PageIndex");
            //    });
        }
    }
}
