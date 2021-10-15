﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Week4_EsFinale_Dal_Savio.Core;

namespace Week4_EsFinale_Dal_Savio.EF
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public OrderContext() : base()
        {

        }
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                string connectionString = @"Server = (localdb)\mssqllocaldb;
                Database = OrdersDb; Trusted_Connection = True;";
                options.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Order>(new OrderConfiguration());
        }
    }
}
