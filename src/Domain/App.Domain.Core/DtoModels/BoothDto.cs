using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class BoothDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int OwnerUserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Description { get; set; } = null!;

        public int TotalSalesNumber { get; set; }

        public int? BoothImageId { get; set; }

        public bool IsDeleted { get; set; }

        public int CityId { get; set; }

        public bool IsCreated { get; set; }

        public virtual ImageDto? BoothImage { get; set; }

        public virtual ICollection<CartDto> Carts { get; set; } = new List<CartDto?>();

        public virtual CityDto? City { get; set; } = null!;

        public virtual ICollection<CommentDto?> Comments { get; set; } = new List<CommentDto?>();

        public virtual ICollection<OrderDto?> Orders { get; set; } = new List<OrderDto?>();

        public virtual AppUserDto? OwnerUser { get; set; } = null!;
    }
}
