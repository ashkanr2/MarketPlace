using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class ProductImageDto
    {
        public int Id { get; set; }

        public int ImageId { get; set; }

        public int ProductId { get; set; }

        public virtual ImageDto Image { get; set; } = null!;

        public virtual ProductDto Product { get; set; } = null!;
    }
}
