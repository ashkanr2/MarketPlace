using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class StatusDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public virtual ICollection<OrderDto> Orders { get; set; } = new List<OrderDto>();
    }
}
