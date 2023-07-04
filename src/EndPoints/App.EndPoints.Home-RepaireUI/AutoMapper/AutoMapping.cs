using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Entities;
using App.Domain.Core.DtoModels;
using AutoMapper;
using App.EndPoints.Home_RepaireUI.Models;
using App.EndPoints.Home_RepaireUI.Models.Product;

namespace App.EndPoints.Home_RepaireUI.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {

            //User 
            
            CreateMap<AppUser, AppUserDto>();
            
    

            CreateMap<Auction, AuctionDto>();
            CreateMap<AuctionDto, Auction>();

            CreateMap<AllProduct, AllProductDto>();

            CreateMap<Bid, BidDto>();

            CreateMap<Booth, BoothDto>();
            CreateMap<BoothDto, Booth>();

            CreateMap<BuyerMedal, BuyerMedalDto>();

            CreateMap<Category, CategoryDto>();

            CreateMap<City, CityDto>();

            CreateMap<Comment, CommentDto>();

            CreateMap<Image, ImageDto>();

           
            CreateMap<Cart, CartDto>();
            CreateMap<CartDto, Cart>();

            CreateMap<CartProduct, CartProductDto>();
            CreateMap<CartProductDto, CartProduct>();

            CreateMap<MothersCategory, MothersCategoryDto>();

            CreateMap<Order, OrderDto>();


            CreateMap<OrderProduct, OrderProductDto>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto , Product>();
            CreateMap<ProductDto, ProductViewModel>();
            CreateMap<ProductViewModel, ProductDto>();

            CreateMap<ProductImage, ProductImageDto>();

            CreateMap<Province, ProvinceDto>();

            CreateMap<SellerInformation, SellerInformationDto>();



            CreateMap<SellerMedal, SellerMedalDto>();
            CreateMap<SellerInformation, SellerInformationDto>();
            CreateMap<Status, StatusDto>();



        }
    }
}
