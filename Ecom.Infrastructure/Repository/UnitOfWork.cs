using Ecom.Core.Interfaces;
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
        public ICategoryRepository CategoryRepository {  get;}

        public IProductRepository ProductRepository { get; }

        public IPhotoRepository PhotoRepository { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context= context;
            CategoryRepository= new CategoryRepository(_context);
            ProductRepository= new ProductRepository(_context);
            PhotoRepository=new PhotoRepositry(_context);
        }
    }
}
