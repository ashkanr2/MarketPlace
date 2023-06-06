using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int BoothId { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual Booth Booth { get; set; } = null!;

        public virtual ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

        public virtual AppUser User { get; set; } = null!;

    }
}
