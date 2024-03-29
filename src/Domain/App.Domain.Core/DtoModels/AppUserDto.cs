﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class AppUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; } = null!;

        public DateTimeOffset CreatAt { get; set; }

        public bool? IsDeleted { get; set; }

        public int? BuyerMedalId { get; set; }

        public string? CountOfBuy { get; set; }

        public int? UserProfileImageId { get; set; }

        public bool IsSeller { get; set; }

        public bool IsCreated { get; set; }

        public int? Wallet { get; set; }

        public virtual ICollection<BoothDto> Booths { get; set; } = new List<BoothDto>();

        public virtual BuyerMedalDto? BuyerMedal { get; set; }

        public virtual ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();

        public virtual ICollection<OrderDto> Orders { get; set; } = new List<OrderDto>();
        public virtual ICollection<CartDto> Carts { get; set; } = new List<CartDto>();

        public virtual ICollection<SellerInformationDto> SellerInformations { get; set; } = new List<SellerInformationDto>();

        public virtual ImageDto? UserProfileImage { get; set; }


    }
}
