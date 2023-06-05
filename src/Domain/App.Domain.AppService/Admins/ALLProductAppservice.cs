using App.Domain.Core.AppServices.Admin;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Admins
{
    public class ALLProductAppservice : IALLProductAppservice
    {
        private readonly IAllProductRepository _allProductRepository;
        private readonly IMapper _mapper;

        public ALLProductAppservice(IAllProductRepository repository, IMapper mapper)
        {
            _allProductRepository = repository;
            _mapper = mapper;
        }

        public async Task Active(int AllproductId, CancellationToken cancellationToken)
        {
            var Allproduct = await _allProductRepository.GetDatail(AllproductId, cancellationToken);
            Allproduct.IsCreated = true;
            Allproduct.IsDeleted = false;
            await _allProductRepository.Update(Allproduct, cancellationToken);
        }

        public async Task Create(AllProductDto allProduct, CancellationToken cancellationToken)
        {
           await _allProductRepository.Create(allProduct, cancellationToken);
        }

        public async Task DiActive(int AllproductId, CancellationToken cancellationToken)
        {

            var Allproduct = await _allProductRepository.GetDatail(AllproductId, cancellationToken);
            Allproduct.IsDeleted = true;
            await _allProductRepository.Update(Allproduct, cancellationToken);
        }

        public async Task<List<AllProductDto>> GetAlCategoryId(int categoryId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();

        }

        public async Task<List<AllProductDto>> GetAll(CancellationToken cancellationToken)
            =>await _allProductRepository.GetAll(cancellationToken);
        

        public Task<List<AllProductDto>> GetAlMotherCategoryId(int motherCategoryId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<AllProductDto> GetDatail(int AllproductId, CancellationToken cancellationToken)
        => await _allProductRepository.GetDatail(AllproductId, cancellationToken);
            
        

        public async Task HardDelted(int AllproductId, CancellationToken cancellationToken)
         => await _allProductRepository.HardDelted(AllproductId, cancellationToken);
        public async Task SoftDelete(int AllproductId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Update(AllProductDto allProduct, CancellationToken cancellationToken)
        => await _allProductRepository.Update(allProduct, cancellationToken);
    }
}
