using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Helpers;

namespace AccountOwnerServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Owner, OwnerDto>();

            CreateMap<Account, AccountDto>();

            CreateMap<OwnerForCreationDto, Owner>();

            CreateMap<AccountForCreationDto, Account>();

            CreateMap<OwnerForUpdateDto, Owner>();

            CreateMap<Category, CategoryDto>();

            CreateMap<CategoryForCreationDto, Category>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.ImageFile.FileName));

            CreateMap<Product, ProductDto>();

            CreateMap<Category, CategoryWithProductsDto>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            CreateMap<CategoryForUpdateDto, Category>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.ImageFile.FileName));

            CreateMap<ProductForCreationDto, Product>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Comments, opt => opt.Ignore())
            .ForMember(dest => dest.Ratings, opt => opt.Ignore())
            .ForMember(dest => dest.OrderItems, opt => opt.Ignore())
            .ForMember(dest => dest.CartItems, opt => opt.Ignore());

            CreateMap<ProductForUpdateDto, Product>()
                .ForMember(dest => dest.Comments, opt => opt.Ignore())
                .ForMember(dest => dest.Ratings, opt => opt.Ignore()); 

            CreateMap<MediaFileForCreationDto, MediaFile>();

            CreateMap<MediaFile, MediaFileForRetrievalDto>();

            CreateMap<MediaFile, MediaFileDto>();

            CreateMap<Cart, CartDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.CartItems, opt => opt.MapFrom(src => src.CartItems))
            .ForMember(dest => dest.TotalCost, opt => opt.Ignore());

            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.CartId))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.ProductFileName, opt => opt.MapFrom(src => src.Product.MediaFiles.FirstOrDefault().FileName))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.ProductPrice))
                .ForMember(dest => dest.MaxQuantity, opt => opt.MapFrom(src => src.Product.MaxQuantity))
                .ForMember(dest => dest.MinQuantity, opt => opt.MapFrom(src => src.Product.MinQuantity))
                .ForMember(dest => dest.QuantityUnit, opt => opt.MapFrom(src => src.Product.QuantityUnit))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Product.Discount))
                .ForMember(dest => dest.FinalPrice, opt => opt.Ignore())
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<CartDto, Cart>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.CartItems, opt => opt.MapFrom(src => src.CartItems));

            CreateMap<CartItemDto, CartItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.CartId))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.SellerName, opt => opt.MapFrom(src => src.Seller.Name))
            .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.OrderItems.Sum(oi => oi.Quantity * decimal.Parse(oi.Product.ProductPrice))));

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.ProductPrice));
        }
    }
}
