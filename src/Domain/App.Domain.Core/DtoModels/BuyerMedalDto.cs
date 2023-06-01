using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class BuyerMedalDto
    {
        public int Id { get; set; }

        public int DiscountPercent { get; set; }

        public int CountOfBuy { get; set; }

        public virtual ICollection<AppUserDto> AppNetUsers { get; set; } = new List<AppUserDto>();
    }
}
