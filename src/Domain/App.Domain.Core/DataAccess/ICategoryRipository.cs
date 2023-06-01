using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface ICategoryRipository
    {
        Task<List<CategoryDto>> GetAll(int motherCategoryId,CancellationToken cancellationToken);
        Task<CategoryDto> GetDatail(int categoryId, CancellationToken cancellationToken);
        Task Create(CategoryDto category, CancellationToken cancellationToken);
        Task Update(CategoryDto categor, CancellationToken cancellationToken);
        Task SoftDelete(int categoryId, CancellationToken cancellationToken);
        Task HardDelted(int categoryId, CancellationToken cancellationToken);

    }
}
