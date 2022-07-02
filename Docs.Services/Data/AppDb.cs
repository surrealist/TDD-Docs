﻿using Docs.Models;
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



  }
}
