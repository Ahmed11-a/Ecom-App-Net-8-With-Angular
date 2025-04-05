using AutoMapper;
using Ecom.Core.Interfaces;
using Ecom.Core.Services;
using Ecom.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork   
    {
        public readonly AppDbContext _context;
        private readonly IMapper mapper;
        private readonly IImageManagementService imageManagementService;
        public ICategoryRepository CategoryRepository {  get;}

        public IProductRepository ProductRepository { get; }

        public IPhotoRepository PhotoRepository { get; }

        public UnitOfWork(AppDbContext context, IMapper mapper, IImageManagementService imageManagementService)
        {
            _context = context;
            this.mapper = mapper;
            this.imageManagementService = imageManagementService;
            CategoryRepository = new CategoryRepository(_context);
            ProductRepository = new ProductRepository(_context,mapper,imageManagementService);
            PhotoRepository = new PhotoRepositry(_context);

        }
    }
}
