using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Repository
{
    public class PhotoRepositry : GenericRepository<Photo>, IPhotoRepository 
    {
        public PhotoRepositry(AppDbContext context) : base(context)
        {
        }
    }
}
