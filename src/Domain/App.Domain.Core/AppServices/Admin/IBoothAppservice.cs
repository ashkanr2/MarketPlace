using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Admins
{
    public interface IBoothAppservice
    {
        Task Active(int boothId, CancellationToken cancellationToken);
        Task DiActive(int boothId, CancellationToken cancellationToken);
        Task<List<BoothDto>> GetCitiesBooth(int cityId, CancellationToken cancellationToken);
        Task<List<BoothDto>> GetAll( CancellationToken cancellationToken);
        Task<BoothDto> GetDatail(int boothId, CancellationToken cancellationToken);
        Task Create(BoothDto booth, CancellationToken cancellationToken);
        Task<BoothDto> GetUserBooth(int userId, CancellationToken cancellationToken);
        Task Update(BoothDto booth, CancellationToken cancellationToken);
        Task SoftDelete(int boothId, CancellationToken cancellationToken);
        Task HardDelted(int boothId, CancellationToken cancellationToken);
    }
}
