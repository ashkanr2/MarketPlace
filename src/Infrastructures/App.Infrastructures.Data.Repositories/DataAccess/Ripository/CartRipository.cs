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

    public class CartRipository : ICartRipository
    {
        private readonly MarketPlaceDb _context;
        private readonly IMapper _mapper;
        public CartRipository(MarketPlaceDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(CartDto cart, CancellationToken cancellationToken)
        {
           var item =  _mapper.Map<Cart>(cart);
               await _context.Carts.AddAsync(item) ;
            _context.SaveChanges() ;

        }

        public async Task<List<CartDto>> GetAll(CancellationToken cancellationToken)
        => _mapper.Map<List<CartDto>>(await _context.Carts.ToListAsync(cancellationToken));
        
       
        public async Task<List<CartDto>> GetAllBooth(int boothID, CancellationToken cancellationToken)
        {
           var BoothCarts = _mapper.Map<List<CartDto>>(await _context.Carts.AsNoTracking().Where(a=>a.BoothId==boothID).ToListAsync());
            return BoothCarts ;
        }

        public async Task<List<CartDto>> GetAllUserCarts(int userID, CancellationToken cancellationToken)
        {
            var UserCarts = _mapper.Map<List<CartDto>>(await _context.Carts
                .Include(p=>p.CartProducts)
                .ThenInclude(c=>c.Product)
                .AsNoTracking().Where(a => a.UserId == userID).ToListAsync());

            return UserCarts;
        }

        public async Task<CartDto> GetDatail(int cartId, CancellationToken cancellationToken)
        {
            var item = await _context.Carts
                .Include(c => c.CartProducts)
                    .ThenInclude(cp => cp.Product)
                .Where(c => c.Id == cartId)
                .FirstOrDefaultAsync();

            var cartDto = _mapper.Map<CartDto>(item);
            return cartDto;
        }

        public async Task HardDelted(int cartId, CancellationToken cancellationToken)
        {
            var item =_mapper.Map<Cart>(GetDatail(cartId, cancellationToken));
            if (item != null)
            {
                _context.Remove<Cart>(item);
                try
                {
                    await _context.SaveChangesAsync(cancellationToken);

                }
                catch (Exception ex)
                {
                    //_loger.LogError("Error in HardDelete order {exception}", ex);
                }
            }
        }

        public Task Update(CartDto booth, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
