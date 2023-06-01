﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Entities;
using App.Domain.Core.DtoModels;
using AutoMapper;

namespace App.Infrastructures.Data.Repositories.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {

            //User 
            CreateMap<AppUser, AppUserDto>();

            //CreateMap<Auction, AuctionDto>();

            CreateMap<AllProduct, AllProductDto>();

            CreateMap<Bid, BidDto>();

            CreateMap<Booth, BoothDto>();

            CreateMap<BuyerMedal, BuyerMedalDto>();

            CreateMap<Category, CategoryDto>();

            CreateMap<City, CityDto>();

            CreateMap<Comment, CommentDto>();

            CreateMap<Image, ImageDto>();

           

            CreateMap<MothersCategory, MothersCategoryDto>();

            CreateMap<Order, OrderDto>();


            CreateMap<OrderProduct, OrderProductDto>();

            CreateMap<Product, ProductDto>();



            CreateMap<ProductImage, ProductImageDto>();

            CreateMap<Province, ProvinceDto>();

            CreateMap<SellerInformation, SellerInformationDto>();



            CreateMap<SellerMedal, SellerMedalDto>();
            CreateMap<SellerInformation, SellerInformationDto>();
            CreateMap<Status, StatusDto>();



        }
    }
}