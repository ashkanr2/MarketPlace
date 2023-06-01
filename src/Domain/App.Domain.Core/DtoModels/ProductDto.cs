using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class ProductDto
    {
        public int Id { get; set; }

        public int UnitPrice { get; set; }

        public int BoothId { get; set; }

        public int AllProductId { get; set; }

        public DateTime? AddTime { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsAccepted { get; set; }

        public virtual AllProductDto AllProduct { get; set; } = null!;

        public virtual ICollection<AuctionDto> Auctions { get; set; } = new List<AuctionDto>();

        public virtual ICollection<OrderProductDto> OrderProducts { get; set; } = new List<OrderProductDto>();

        public virtual ICollection<ProductImageDto> ProductImages { get; set; } = new List<ProductImageDto>();
    }
}
