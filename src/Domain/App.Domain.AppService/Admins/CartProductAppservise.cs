using App.Domain.Core.AppServices.Admin;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Admins
{
    public class CartProductAppservise : ICartProductAppservise
    {
        private readonly ICartProductRipository _cartProductRipository;

        public CartProductAppservise(ICartProductRipository cartProductRipository)
        {
            _cartProductRipository = cartProductRipository;
        }

        public async Task Create(CartProductDto cartProduct, CancellationToken cancellationToken)
        =>await _cartProductRipository.Create(cartProduct, cancellationToken);

        public async Task<List<ProductDto>> GetAllProduct(int cartId, CancellationToken cancellationToken)
        =>await _cartProductRipository.GetAllProduct(cartId, cancellationToken);
        public async Task<CartProductDto> GetDatail(int id, CancellationToken cancellationToken)
        =>await _cartProductRipository.GetDatail(id, cancellationToken);
        public async Task HardDelete(int id, CancellationToken cancellationToken)
        =>await _cartProductRipository.HardDelete(id, cancellationToken);
        public async Task Update(CartProductDto cartProduct, CancellationToken cancellationToken)
        =>await _cartProductRipository.Update(cartProduct, cancellationToken);
        public async Task<int> FindId(int productId, int cartId, CancellationToken cancellationToken)
        =>await _cartProductRipository.FindId(productId, cartId, cancellationToken);

        
    }
}
