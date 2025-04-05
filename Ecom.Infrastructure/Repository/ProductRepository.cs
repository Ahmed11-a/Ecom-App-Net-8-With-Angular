using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Ecom.Core.Services;
using Ecom.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IImageManagementService imageManagementService;
        public ProductRepository(AppDbContext context, IMapper mapper, IImageManagementService imageManagementService) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.imageManagementService = imageManagementService;
        }

        public async Task<bool> AddAsync(AddProductDTO productDTO)
        {
            if (productDTO == null)
                return false;
            var product=mapper.Map<Product>(productDTO);
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            var ImagePath = await imageManagementService.AddImageAsync(productDTO.Photos, productDTO.Name);
            var photos=ImagePath.Select(path=> 
            new Photo { ImageName=path ,ProductId=product.Id}).ToList();
            await context.Photos.AddRangeAsync(photos);
            await context.SaveChangesAsync();

            return true;

        }

        public async Task<bool> UpdateAsync(UpdateProductDTO productDTO)
        {
            if (productDTO is  null)
                return false;
            var findProduct=await context.Products
                .Include(p=>p.Category)
                .Include(p=>p.Photos)
                .FirstOrDefaultAsync(p=>p.Id == productDTO.Id);
            if(findProduct is null)
                return false;
             mapper.Map(productDTO,findProduct);

            var findPhoto=await context.Photos.Where(p=>p.ProductId== productDTO.Id).ToListAsync();
            foreach(var item in findPhoto)
            {
                imageManagementService.DeleteImageAsync(item.ImageName);
            }
            context.Photos.RemoveRange(findPhoto);

            var ImagePath = await imageManagementService.AddImageAsync(productDTO.Photos, productDTO.Name);

            var photo = ImagePath.Select(path => new Photo { ImageName = path, ProductId = productDTO.Id }).ToList();
            await context.Photos.AddRangeAsync(photo);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
