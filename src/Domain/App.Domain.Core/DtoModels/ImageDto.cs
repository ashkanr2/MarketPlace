using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class ImageDto
    {
        public int Id { get; set; }

        public string Path { get; set; } = null!;

        public bool Isdeleted { get; set; }

        public bool IsProfileImage { get; set; }

        public bool IsAccepted { get; set; }

        public virtual ICollection<AppUserDto> AppNetUsers { get; set; } = new List<AppUserDto>();

        public virtual ICollection<BoothDto> Booths { get; set; } = new List<BoothDto>();

        public virtual ICollection<ProductImageDto> ProductImages { get; set; } = new List<ProductImageDto>();
    }
}
