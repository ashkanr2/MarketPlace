using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class CartDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int BoothId { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual BoothDto Booth { get; set; } = null!;

        public virtual ICollection<CartProductDto> CartProducts { get; set; } = new List<CartProductDto>();

        public virtual AppUserDto User { get; set; } = null!;

    }
}
