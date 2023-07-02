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
using System.Threading;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.DataAccess.Ripository
{
    public class OrderRipository : IOrderRipository
    {
        private readonly MarketPlaceDb _context;
        private readonly IMapper _mapper;

        public OrderRipository(MarketPlaceDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(OrderDto order, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Order>(order);
            record.OrderCreatTime = DateTime.Now;
            record.IsDeleted = false;
            try
            {
                await _context.Orders.AddAsync(record);
                await _context.SaveChangesAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                //_loger.LogError("Error in add new Order {exception}", ex);
            }
        }

        public async Task<List<OrderDto>> GetAllBoothOrders(int BoothId, CancellationToken cancellationToken)
        => _mapper.Map<List<OrderDto >> (await _context.Orders
            .AsNoTracking()
            .Where(x => x.BoothId == BoothId)
            .ToListAsync(cancellationToken));
      
            
       
        public async Task<List<OrderDto>> GetAllOrders(CancellationToken cancellationToken)
        => _mapper.Map<List<OrderDto>>(await _context.Orders
            .AsNoTracking()
            .Include(x => x.Booth)
            .Include(s=>s.Status)
            .Include(u=>u.User)
            .ToListAsync(cancellationToken));

        public async Task<List<OrderDto>> GetAllUserOrders(int userId, CancellationToken cancellationToken)
         => _mapper.Map<List<OrderDto>>(await _context.Orders
            .AsNoTracking()
            .Include(x => x.Booth)
            .Include(s => s.Status)
            .Include(u => u.User)
             .Where(u=>u.UserId==userId)
            .ToListAsync(cancellationToken));

        public async Task<OrderDto> GetDatail(int orderId, CancellationToken cancellationToken)
       => _mapper.Map<OrderDto>(await _context.Orders
           .AsNoTracking()
           .Where(x => x.Id == orderId).FirstOrDefaultAsync());

        public async Task HardDelted(int orderId, CancellationToken cancellationToken)
        {
           var order = await _context.Orders
           .AsNoTracking()
           .Where(x => x.Id == orderId).FirstOrDefaultAsync();
            if (order != null)
            {
                _context.Remove<Order>(order);
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
        public async Task SoftDelete(int orderId, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
          .AsNoTracking()
          .Where(x => x.Id == orderId).FirstOrDefaultAsync();
            order.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task Update(OrderDto order, CancellationToken cancellationToken)
        {
           var record = await _context.Orders
                .Where(a=>a.Id==order.Id)
                .FirstOrDefaultAsync(cancellationToken);
            if (record != null)
            {
                record.StatusId = order.StatusId;
                record.IsDeleted = order.IsDeleted;
                record.TotalPrice= order.TotalPrice;
                
            }
            try
            {
                await _context.SaveChangesAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                //_loger.LogError("Error in Update order {exception}", ex);
            }
            
        }
    }
}
