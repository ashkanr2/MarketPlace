using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface ISellerInformationRepository
    {
        Task<List<SellerInformationDto>> GetAll(int cityId, CancellationToken cancellationToken);
        Task<SellerInformationDto> GetDatail(string userId, CancellationToken cancellationToken);
        Task Create(string userID, int nationalCode,int zipAddress,int cityId, CancellationToken cancellationToken);
        Task Update(SellerInformationDto sellerInformation, CancellationToken cancellationToken);
        Task SoftDelete(int sellerInformationId, CancellationToken cancellationToken);
        Task HardDelted(int sellerInformationId, CancellationToken cancellationToken);


    }
}
