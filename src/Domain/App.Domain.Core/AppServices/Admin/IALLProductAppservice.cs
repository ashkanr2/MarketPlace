using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Admin
{
    public interface IALLProductAppservice
    {
        Task Active(int AllproductId, CancellationToken cancellationToken);
        Task DiActive(int AllproductId, CancellationToken cancellationToken);
        Task<List<AllProductDto>> GetAll(CancellationToken cancellationToken);
        Task<List<AllProductDto>> GetAlCategoryId(int categoryId, CancellationToken cancellationToken);
        Task<List<AllProductDto>> GetAlMotherCategoryId(int motherCategoryId, CancellationToken cancellationToken);
        Task<AllProductDto> GetDatail(int AllproductId, CancellationToken cancellationToken);
        Task Create(AllProductDto allProduct, CancellationToken cancellationToken);
        Task Update(AllProductDto allProduct, CancellationToken cancellationToken);
        Task SoftDelete(int AllproductId, CancellationToken cancellationToken);
        Task HardDelted(int AllproductId, CancellationToken cancellationToken);
    }
}
