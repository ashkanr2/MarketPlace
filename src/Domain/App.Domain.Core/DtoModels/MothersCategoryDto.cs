using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class MothersCategoryDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public virtual ICollection<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }
}
