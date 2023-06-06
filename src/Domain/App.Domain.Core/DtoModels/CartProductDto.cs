using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class CartProductDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int CartId { get; set; }

        public virtual CartDto Cart { get; set; } = null!;

        public virtual ProductDto Product { get; set; } = null!;
    }
}
