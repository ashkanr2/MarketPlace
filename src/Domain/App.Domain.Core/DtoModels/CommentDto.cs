using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class CommentDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Comment1 { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public int BoothId { get; set; }

        public int OrderId { get; set; }

        public bool IsAccepted { get; set; }

        public virtual BoothDto Booth { get; set; } = null!;

        public virtual OrderDto Order { get; set; } = null!;

        public virtual AppUserDto User { get; set; } = null!;
    }
}
