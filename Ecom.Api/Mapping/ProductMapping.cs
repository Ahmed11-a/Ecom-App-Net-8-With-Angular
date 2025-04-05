using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;

namespace Ecom.Api.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductDTO>().ForMember
                (DTO => DTO.CategoryName, 
                x => x.MapFrom(src => src.Category.Name))
                .ReverseMap();

            CreateMap<Photo, PhotoDTO>().ReverseMap();
            CreateMap<AddProductDTO, Product>()
                .ForMember(m => m.Photos, x => x.Ignore())
                .ReverseMap();
            CreateMap<UpdateProductDTO, Product>()
              .ForMember(m => m.Photos, x => x.Ignore())
              .ReverseMap();


        }

    }
}
