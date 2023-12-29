using APISample.MyApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.MyApi.Models.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions opt):base (opt)
        {

        }

        public DbSet<Shippers> Shippers { get; set; }
        public DbSet<OrderDetail> Order_Detail { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
