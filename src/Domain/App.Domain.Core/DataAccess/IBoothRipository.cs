using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface IBoothRipository
    {
      
        
        Task<BoothDto> GetDatail(int boothId, CancellationToken cancellationToken);
        Task Create(BoothDto booth, CancellationToken cancellationToken);
        Task<List<BoothDto>> GetAll(CancellationToken cancellationToken);
        Task Update(BoothDto booth, CancellationToken cancellationToken);
        Task SoftDelete(int boothId, CancellationToken cancellationToken);
        Task HardDelted(int boothId, CancellationToken cancellationToken);

    }
}
