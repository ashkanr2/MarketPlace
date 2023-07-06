using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Admins
{
    public interface IProductAppservice
    {
        
        Task<ProductDto> GetDetail(int productId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetBoothProducts(int boothId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetCategoryProducts(int CategoryId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAll( CancellationToken cancellationToken);
        Task<List<ProductDto>> GetMCAtegoryProducts(int MCId, CancellationToken cancellationToken);
        Task<List<ProductDto>> Search(string name, CancellationToken cancellationToken);
        Task<int> Create(ProductDto product, CancellationToken cancellationToken);
        Task Deactivate(int producttId, CancellationToken cancellationToken);
        Task SoftDelete(int producttId, CancellationToken cancellationToken);
        Task OnDelete(int producttId, CancellationToken cancellationToken);
        Task Active(int productId, CancellationToken cancellationToken);
        Task Update(ProductDto product, CancellationToken cancellationToken);
        
    }
}
