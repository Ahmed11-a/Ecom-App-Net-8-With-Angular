using Ecom.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Data.Config
{
    public class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(category=> category.Name).IsRequired().HasMaxLength(30);
            builder.Property(category => category.Id).IsRequired();
            builder.HasData(
                new Category { Id = 1, Name = "test", Description = "test" }
                );
        }
    }
}
