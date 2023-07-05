using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Admin
{
    public interface ICategoryAppservice
    {
        Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken);
        Task<CategoryDto> GetDatail(int categoryId, CancellationToken cancellationToken);
        Task Create(CategoryDto category, CancellationToken cancellationToken);
        Task Update(CategoryDto categor, CancellationToken cancellationToken);
        Task HardDelted(int categoryId, CancellationToken cancellationToken);
    }
}
