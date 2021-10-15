using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Week4_EsFinale_Dal_Savio.Core;

namespace Week4_EsFinale_Dal_Savio.EF
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(b => b.CustomerId);

            builder
                .Property(b => b.CodiceOrdine)
                .IsRequired();

            builder
                .Property(b => b.CodiceProdotto)
                .IsRequired();

            builder
                .Property(b => b.DataOrdine)
                .IsRequired();

            builder
                .HasOne(p => p.Cliente)
                .WithMany(b => b.Orders)
                .HasForeignKey(b => b.CustomerId);
        }
    }
}
