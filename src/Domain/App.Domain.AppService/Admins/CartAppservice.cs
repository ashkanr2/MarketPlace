using App.Domain.Core.AppServices.Admin;
using App.Domain.Core.AppServices.Admins;
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
        private readonly IAppUserRipositry _appUserRipositry;
        private readonly IOrderAppservice _orderAppservice;
        private readonly IProductAppservice _productAppservice;
        public CartAppservice(ICartRipository cartRipository, ICartProductAppservise cartProductAppservise, IAppUserRipositry appUserRipositry, IOrderAppservice orderAppservice, IProductAppservice productAppservice)
        {
            _cartRipository = cartRipository;
            _cartProductAppservise = cartProductAppservise;
            _appUserRipositry = appUserRipositry;
            _orderAppservice = orderAppservice;
            _productAppservice = productAppservice;
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

        public async Task<int> CreateOrder(int cartId, AppUserDto user, CancellationToken cancellationToken)
        {
                var cart = await GetDatail(cartId, cancellationToken);
            int totalprice = cart.CartProducts.Sum(cp => cp.Product.UnitPrice);
            var orderProducts = cart.CartProducts.Select(cp => new OrderProductDto
            {
                ProductId = cp.Product.Id,
                Product = cp.Product,
            }).ToList();
            
            var Order = new OrderDto
            {
                UserId = cart.UserId,
                StatusId = 1,
                IsDeleted = false,
                BoothId = cart.BoothId,
                TotalPrice = totalprice,
                Commission = totalprice / 10,
                OrderCreatTime = DateTime.Now,

            };

            int OrderId = await _orderAppservice.Create(Order, cancellationToken);
            Order.Id=OrderId;
            await _orderAppservice.CreateOrderProducts(OrderId, orderProducts, cancellationToken);
            await _appUserRipositry.IncreaseWallet(1, Order.Commission, cancellationToken);
            await _appUserRipositry.DecreaseWallet(user.Id, Order.TotalPrice, cancellationToken);
            //await HardDelted(cartId, cancellationToken);
           
            return OrderId;
        }
    }
}
