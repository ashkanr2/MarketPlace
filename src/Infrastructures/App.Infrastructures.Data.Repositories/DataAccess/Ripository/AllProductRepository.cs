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
    public class AllProductRepository:IAllProductRepository
    {
        private readonly IMapper _mapper;
        private readonly MarketPlaceDb _context;

        public AllProductRepository(IMapper mapper, MarketPlaceDb context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Create(AllProductDto entity, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<AllProduct>(entity);
            record.IsDeleted = false;
            record.IsCreated = true;
            try
            {
                await _context.AllProducts.AddAsync(record);
                await _context.SaveChangesAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                //_loger.LogError("Error in add new Order {exception}", ex);
            }
        }

        public async Task<List<AllProductDto>> GetAll(CancellationToken cancellationToken)
        => _mapper.Map<List<AllProductDto>>(await _context.AllProducts
                .AsNoTracking()
                .ToListAsync(cancellationToken));

        public async Task<AllProductDto> GetDatail(int AllProductId, CancellationToken cancellationToken)
         => await Task.FromResult(_mapper.Map<AllProductDto>(await _context.AllProducts
             .AsNoTracking()
             .Where(x => x.Id == AllProductId)
              .FirstOrDefaultAsync(cancellationToken)));

        public async Task HardDelted(int AllProductId, CancellationToken cancellationToken)
        {
            var Allproduct = await _context.AllProducts
              .Where(x => x.Id == AllProductId)
              .FirstOrDefaultAsync(cancellationToken);
            if (Allproduct != null)
            {
                _context.Remove<AllProduct>(Allproduct);
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

        public async Task Update(AllProductDto AllProduct, CancellationToken cancellationToken)
        {
            var record = await _mapper.ProjectTo<AllProductDto>(_context.Set<AllProductDto>())
                  .Where(x => x.Id == AllProduct.Id).FirstOrDefaultAsync();
            _mapper.Map(AllProduct, record);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
