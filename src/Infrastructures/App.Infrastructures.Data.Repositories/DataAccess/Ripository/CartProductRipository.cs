using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.DataBase;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.DataAccess.Ripository
{
    public class CartProductRipository : ICartProductRipository
    {
        private readonly MarketPlaceDb _context;
        private readonly IMapper _mapper;
        public CartProductRipository(MarketPlaceDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(CartProductDto cartProduct, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<CartProduct>(cartProduct);
            await _context.CartProducts.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductDto>> GetAllProduct(int cartId, CancellationToken cancellationToken)
        {
            var AllItem = _mapper.Map<List<ProductDto>>(await _context.CartProducts.Where(x => x.CartId == cartId).ToListAsync());
            return AllItem;
        }

        public async Task<CartProductDto> GetDatail(int id, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<CartProductDto>(await _context.CartProducts.Where(x => x.Id == id).FirstOrDefaultAsync());
            return item;
        }

        public async Task HardDelete(int id, CancellationToken cancellationToken)
        {

            var item = _mapper.Map<CartProduct>(await GetDatail(id, cancellationToken));
            _context.CartProducts.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(CartProductDto cartProduct, CancellationToken cancellationToken)
        {
            var item = await GetDatail(cartProduct.Id, cancellationToken);

            if (item != null)
            {
                item.ProductId = cartProduct.ProductId;
                item.CartId = cartProduct.CartId;
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
        public async Task<int>FindId(int productId, int cartId, CancellationToken cancellationToken)
        {
            var id = (await _context.CartProducts.Where(c=>c.CartId == cartId && c.ProductId == productId).FirstOrDefaultAsync()).Id;
            return id;
        }
    }
}
