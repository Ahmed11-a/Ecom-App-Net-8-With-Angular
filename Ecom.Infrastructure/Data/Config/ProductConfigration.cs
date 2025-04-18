﻿using Ecom.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Data.Config
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(product=>product.Name).IsRequired();
            builder.Property(product=>product.Description).IsRequired();
            builder.Property(product=>product.NewPrice).HasColumnType("decimal(18,2)");
            builder.HasData(new Product { Id = 1, Name = "test", Description = "test", CategoryId = 1, NewPrice = 12 });
        }
    }
}
