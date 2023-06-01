using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class SellerInformationDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string NationalCode { get; set; } = null!;

        public int ZipCode { get; set; }

        public string Address { get; set; } = null!;

        public int? CountOfSell { get; set; }

        public int? SellerMedalId { get; set; }

        public int CityId { get; set; }

        public virtual CityDto City { get; set; } = null!;

        public virtual SellerMedalDto? SellerMedal { get; set; }

        public virtual AppUserDto User { get; set; } = null!;
    }
}
