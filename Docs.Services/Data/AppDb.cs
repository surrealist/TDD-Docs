using Docs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Services.Data
{
  public class AppDb : DbContext
  {

    public AppDb(DbContextOptions<AppDb> options): base(options)
    {
      //
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<OrderDetail>()
         .HasKey(x => new { x.OrderId, x.LineId});

      modelBuilder.Entity<OrderDetail>()
        .Property(x => x.SalePrice)
        .HasPrecision(18, 2);

      base.OnModelCreating(modelBuilder);
    }

  }
}
