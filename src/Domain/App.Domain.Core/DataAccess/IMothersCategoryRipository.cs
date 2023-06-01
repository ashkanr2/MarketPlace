using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface IMothersCategoryRipository
    {
        Task<List<MothersCategoryDto>> GetAll( CancellationToken cancellationToken);
        Task<MothersCategoryDto> GetDatail(int motherCategoryId, CancellationToken cancellationToken);
        Task Create(string title, CancellationToken cancellationToken);
        Task Update(MothersCategoryDto motherCategory, CancellationToken cancellationToken);
        Task SoftDelete(int motherCategoryId, CancellationToken cancellationToken);
        Task HardDelted(int motherCategoryId, CancellationToken cancellationToken);
    }
}
