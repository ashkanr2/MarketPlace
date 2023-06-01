using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public int MotherCategoryId { get; set; }

        public virtual ICollection<AllProductDto> AllProducts { get; set; } = new List<AllProductDto>();

        public virtual MothersCategoryDto MotherCategory { get; set; } = null!;
    }
}
