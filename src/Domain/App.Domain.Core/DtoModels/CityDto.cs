using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class CityDto
    {
        public int Id { get; set; }

        public int ProvincesId { get; set; }

        public string Name { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public virtual ICollection<BoothDto> Booths { get; set; } = new List<BoothDto>();

        public virtual ProvinceDto Provinces { get; set; } = null!;

        public virtual ICollection<SellerInformationDto> SellerInformations { get; set; } = new List<SellerInformationDto>();
    }
}
