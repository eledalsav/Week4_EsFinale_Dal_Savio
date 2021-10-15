using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Week4_EsFinale_Dal_Savio.Core;

namespace Week4_EsFinale_Dal_Savio.EF
{
    class CustomerConfiguration :  IEntityTypeConfiguration<Customer>
    {
       
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
               .HasKey(b => b.CustomerId);

            builder
                .Property(b => b.Nome)
                .IsRequired();

            builder
                .Property(b => b.Cognome)
                    .IsRequired();

            builder
                .Property(b => b.CodiceCliente)
                    .IsRequired();

            builder
            .HasMany(b => b.Orders)
                .WithOne();

        }
    }
}
