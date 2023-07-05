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
using AutoMapper.QueryableExtensions;

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
            try
            {
                await _context.Products.AddAsync(record);
                await _context.SaveChangesAsync(cancellationToken);
                Console.WriteLine($"New Product Added Successful");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in add new Product: {ex}");
            }
        }

        public async Task<List<ProductDto>> GetAll(int boothId, CancellationToken cancellationToken)
        {
            var products = await _context.Products
            .AsNoTracking()
             .Where(a => a.BoothId == boothId)
              .Include(x => x.AllProduct)
             .ThenInclude(p => p.Category)
             .Include(i=>i.ProductImages)
            .ToListAsync(cancellationToken);

            var productDtos = _mapper.Map<List<ProductDto>>(products);
            return productDtos;

        }
        public async Task<List<ProductDto>> GetAllFromCategory(int McategoryId, CancellationToken cancellationToken)
        {
            var products = await _context.Products
            .AsNoTracking()
            .Include(x => x.AllProduct)
            .ThenInclude(a => a.Category)
            .Include(i => i.ProductImages)
            .ThenInclude(a => a.Image)
             .Where(x => x.AllProduct.Category.MotherCategoryId == McategoryId)
                .ToListAsync(cancellationToken);

            var productDtos = _mapper.Map<List<ProductDto>>(products);

            return productDtos;
        }

        public async Task<List<ProductDto>> GetAll( CancellationToken cancellationToken)
        {
            var products = await _context.Products
                .AsNoTracking()
                .Include(x => x.AllProduct)
                .ThenInclude(p => p.Category)
                .Include(i => i.ProductImages)
                .ThenInclude(a=>a.Image)
                .ToListAsync(cancellationToken);
            var productDtos = _mapper.Map<List<ProductDto>>(products);
           return productDtos;

        }

        public async Task<ProductDto> GetDatail(int productId, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductDto>(await _context.Products
                .Where(a=>a.Id == productId)
                .Include(x=>x.AllProduct)
                .FirstOrDefaultAsync(cancellationToken));

            return product; 
           
        }
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
            var record = await _context.Products
                 .Where(x => x.Id == product.Id)
                 .FirstOrDefaultAsync(cancellationToken);
            if(record != null)
            {
                record.Name= product.Name;
                record.UnitPrice=product.UnitPrice;
                record.AllProductId=product.AllProductId;
                record.IsAccepted=product.IsAccepted;
                record.IsDeleted=product.IsDeleted;
                record.IsAvailable=product.IsAvailable;
               
            }
            try
            {
                await _context.SaveChangesAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                //_loger.LogError("Error in update product {exception}", ex);
            }
        }
    }
}
