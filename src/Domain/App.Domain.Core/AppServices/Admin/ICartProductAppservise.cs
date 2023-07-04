using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Admin
{
    public interface ICartProductAppservise
    {
        Task<CartProductDto> GetDatail(int id, CancellationToken cancellationToken);
        Task Create(CartProductDto cartProduct, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAllProduct(int cartId, CancellationToken cancellationToken);
        Task Update(CartProductDto cartProduct, CancellationToken cancellationToken);
        Task HardDelete(int id, CancellationToken cancellationToken);
        Task<int> FindId(int productId, int cartId, CancellationToken cancellationToken);
    }
}
