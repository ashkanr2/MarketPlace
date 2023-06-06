using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class OrderDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime OrderCreatTime { get; set; }

        public int StatusId { get; set; }

        public bool IsDeleted { get; set; }

        public int BoothId { get; set; }

        public int TotalPrice { get; set; }

        public int Commission { get; set; }

        public virtual BoothDto Booth { get; set; } = null!;

        public virtual ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();

        public virtual ICollection<OrderProductDto> OrderProducts { get; set; } = new List<OrderProductDto>();

        public virtual StatusDto Status { get; set; } = null!;

        public virtual AppUserDto User { get; set; } = null!;
    }
}
