using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels;
using App.Domain.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Infrastructures.Db.SqlServer.Ef.DataBase;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Data.Repositories.DataAccess.Ripository
{
    public class ProductRipository : IProductRipository
    {
        private readonly IMapper _mapper;
        private readonly MarketPlaceDb _context;

        public ProductRipository(IMapper mapper, MarketPlaceDb context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Create(ProductDto product, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Product>(product);
            record.AddTime = DateTime.Now;
            record.IsAccepted = false;
            try
            {
                await _context.Products.AddAsync(record);
                await _context.SaveChangesAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                //_loger.LogError("Error in add new Order {exception}", ex);
            }
        }

        public async Task<List<ProductDto>> GetAll(int boothId, CancellationToken cancellationToken)
        => _mapper.Map<List<ProductDto>>(await _context.Products
                .AsNoTracking()
                .Where(x => x.BoothId == boothId)
                .ToListAsync(cancellationToken));
        

        public async Task<List<ProductDto>> GetAllFromCategory(int categoryId, CancellationToken cancellationToken)
        {
            var products = await _context.Products
            .AsNoTracking()
            .Include(x => x.AllProduct)
            .ThenInclude(a => a.Category)
             .Where(x => x.AllProduct.CategoryId == categoryId)
   .ToListAsync(cancellationToken);

            var productDtos = _mapper.Map<List<ProductDto>>(products);

            return productDtos;
        }

        public  async Task<ProductDto> GetDatail(int productId, CancellationToken cancellationToken)
         => await Task.FromResult(_mapper.Map<ProductDto>(await _context.Products
             .AsNoTracking()
             .Where(x => x.Id == productId)
              .FirstOrDefaultAsync(cancellationToken)));

        public async Task HardDelted(int productId, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Where(x => x.Id == productId)
                .FirstOrDefaultAsync(cancellationToken);
            _context.Remove(product);
            try
            {
                await _context.SaveChangesAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                //_loger.LogError("Error in HardDelete order {exception}", ex);
            }
        }
        public async Task SoftDelete(int productId, CancellationToken cancellationToken)
        {
            var product = await _context.Products
            .Where(x => x.Id == productId)
            .FirstOrDefaultAsync();
            product.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task Update(ProductDto product, CancellationToken cancellationToken)
        {
            var record = await _mapper.ProjectTo<ProductDto>(_context.Set<ProductDto>())
                 .Where(x => x.Id == product.Id).FirstOrDefaultAsync();
            _mapper.Map(product, record);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
