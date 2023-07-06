using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.AppServices.Admins;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels;
using AutoMapper;
namespace App.Domain.AppService.Admins
{
    public class ProductAppservice : IProductAppservice
    {
        private readonly IProductRipository _productRipository;
        private readonly IMapper _mapper;
        public ProductAppservice(IProductRipository productRipository, IMapper mapper)
        {
            _productRipository = productRipository;
            _mapper = mapper;
        }

        public async Task Active(int productId, CancellationToken cancellationToken)
        {
            var product = await _productRipository.GetDatail(productId, cancellationToken);
            product.IsAccepted = true;
            await _productRipository.Update(product, cancellationToken);
        }

        public async Task<int> Create(ProductDto product, CancellationToken cancellationToken)
       => await _productRipository.Create(product, cancellationToken);
       

        public async Task Deactivate(int productId, CancellationToken cancellationToken)
        {
            
            var product = await _productRipository.GetDatail(productId, cancellationToken);
            product.IsAccepted = false;
            await _productRipository.Update(product, cancellationToken);
        }

        public async Task<List<ProductDto>> GetAll( CancellationToken cancellationToken)
        =>  await _productRipository.GetAll( cancellationToken);
        

        public async Task<List<ProductDto>> GetBoothProducts(int boothId, CancellationToken cancellationToken)
       => await _productRipository.GetAll(boothId, cancellationToken);

        public Task<List<ProductDto>> GetCategoryProducts(int CategoryId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDto> GetDetail(int productId, CancellationToken cancellationToken)
         =>  await _productRipository.GetDatail(productId, cancellationToken);


        public async Task<List<ProductDto>> GetMCAtegoryProducts(int MCId, CancellationToken cancellationToken)
        {
            var item = await _productRipository.GetAllFromCategory(MCId,cancellationToken);
            
            return item;
        }
        public async Task OnDelete(int producttId, CancellationToken cancellationToken)
        {
            var product = await _productRipository.GetDatail(producttId, cancellationToken);
            product.IsDeleted = false;
            await _productRipository.Update(product, cancellationToken);
        }

        public async Task<List<ProductDto>> Search(string name, CancellationToken cancellationToken)
        {
            var products = (await _productRipository.GetAll(cancellationToken)).Where(p=>p.Name == name).ToList();    
            return products;
        }

        public async Task SoftDelete(int producttId, CancellationToken cancellationToken)
        {
           var product = await _productRipository.GetDatail(producttId, cancellationToken);
            product.IsDeleted= true;
            await _productRipository.Update(product,cancellationToken);
        }

        public async Task Update(ProductDto product, CancellationToken cancellationToken)
        {
            await _productRipository.Update(product, cancellationToken);
        }
    }
}
