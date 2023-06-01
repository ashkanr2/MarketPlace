using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface IProvinceRepository
    {
        Task<List<ProvinceDto>> GetAll( CancellationToken cancellationToken);
        Task<ProvinceDto> GetDatail(int provinceId, CancellationToken cancellationToken);
        Task Create(string name, CancellationToken cancellationToken);
        Task Update(ProvinceDto province, CancellationToken cancellationToken);
        Task SoftDelted(int provinceId, CancellationToken cancellationToken);
        Task HardDelted(int provinceId, CancellationToken cancellationToken);
    }
}
