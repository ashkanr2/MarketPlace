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
    public class CartAppservice : ICartAppservice
    {
        private readonly ICartRipository _cartRipository;
        private readonly ICartProductAppservise _cartProductAppservise;

        public CartAppservice(ICartRipository cartRipository, ICartProductAppservise cartProductAppservise)
        {
            _cartRipository = cartRipository;
            _cartProductAppservise = cartProductAppservise;
        }

        public async Task Create(CartDto cart, CancellationToken cancellationToken)
        => await _cartRipository.Create(cart, cancellationToken);
        

        public async Task<List<CartDto>> GetAll(CancellationToken cancellationToken)
        =>  await _cartRipository.GetAll(cancellationToken);
        
        public async Task<List<CartDto>> GetAllBooth(int boothID, CancellationToken cancellationToken)
        =>await _cartRipository.GetAllBooth(boothID, cancellationToken);

        public async Task<List<CartDto>> GetAllUserCarts(int userID, CancellationToken cancellationToken)
        => await _cartRipository.GetAllUserCarts(userID, cancellationToken);

        public async Task<CartDto> GetDatail(int cartId, CancellationToken cancellationToken)
        {
          var item =   await _cartRipository.GetDatail(cartId, cancellationToken);
            return item;
        }
        public async Task HardDelted(int cartId, CancellationToken cancellationToken)
        =>await _cartRipository.HardDelted(cartId, cancellationToken);

        public async Task RemoveProduct(int productId, int cartId, CancellationToken cancellationToken)
        {
            var cartProduct = new CartProductDto
            {
                ProductId = productId,
                CartId = cartId,
            };
            var id =await _cartProductAppservise.FindId(productId,cartId, cancellationToken); 
            await _cartProductAppservise.HardDelete(id, cancellationToken);

        }
        public async Task Addproduct(int productId, int cartId, CancellationToken cancellationToken)
        {
            var cartProduct = new CartProductDto
            {
                ProductId = productId,
                CartId = cartId,
            };
            await _cartProductAppservise.Create(cartProduct, cancellationToken);
        }

        public async Task Update(CartDto booth, CancellationToken cancellationToken)
        =>await _cartRipository.Update(booth, cancellationToken);
    }
}
