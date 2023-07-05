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
    public class CategoryAppservice : ICategoryAppservice
    {
        private readonly ICategoryRipository _categoryRipository;

        public CategoryAppservice(ICategoryRipository categoryRipository)
        {
            _categoryRipository = categoryRipository;
        }
        public async Task Create(CategoryDto category, CancellationToken cancellationToken)
        =>await _categoryRipository.Create(category, cancellationToken);

        public async Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken)
        =>await _categoryRipository.GetAll(cancellationToken);

        public async Task<CategoryDto> GetDatail(int categoryId, CancellationToken cancellationToken)
        =>await _categoryRipository.GetDatail(categoryId, cancellationToken);

        public async Task HardDelted(int categoryId, CancellationToken cancellationToken)
       =>await _categoryRipository.HardDelted(categoryId, cancellationToken);

        public async Task Update(CategoryDto categor, CancellationToken cancellationToken)
       =>await _categoryRipository.Update(categor, cancellationToken);
    }
}
