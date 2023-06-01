using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class SellerMedalDto
    {
        public int Id { get; set; }

        public int DiscountPercent { get; set; }

        public int CountOfSell { get; set; }

        public virtual ICollection<SellerInformationDto> SellerInformations { get; set; } = new List<SellerInformationDto>();
    }
}
