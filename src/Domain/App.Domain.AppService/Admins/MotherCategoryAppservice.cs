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
    public class MotherCategoryAppservice : IMotherCategoryAppservice
    {
        private readonly IMothersCategoryRipository _Ripository;

        public MotherCategoryAppservice(IMothersCategoryRipository ripository)
        {
            _Ripository = ripository;
        }

        public async Task Create(string title, CancellationToken cancellationToken)
        =>await _Ripository.Create(title, cancellationToken);

        public async Task<List<MothersCategoryDto>> GetAll(CancellationToken cancellationToken)
        =>await _Ripository.GetAll(cancellationToken);

        public async Task<MothersCategoryDto> GetDatail(int motherCategoryId, CancellationToken cancellationToken)
        =>await GetDatail(motherCategoryId, cancellationToken);

        public async Task HardDelted(int motherCategoryId, CancellationToken cancellationToken)
       => await _Ripository.HardDelted(motherCategoryId, cancellationToken);

        public async Task SoftDelete(int motherCategoryId, CancellationToken cancellationToken)
        =>await _Ripository.SoftDelete(motherCategoryId, cancellationToken);
        public async Task Update(MothersCategoryDto motherCategory, CancellationToken cancellationToken)
        => await _Ripository.Update(motherCategory, cancellationToken);
    }
}
