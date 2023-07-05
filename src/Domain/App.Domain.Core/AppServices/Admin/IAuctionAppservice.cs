using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Admin
{
    public interface IAuctionAppservice
    {
        Task<AuctionDto> GetDatail(int auctionId, CancellationToken cancellationToken);
        Task<List<AuctionDto>> GetAll(int BoothId, CancellationToken cancellationToken);
        Task<List<AuctionDto>> GetAllAllActions(CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAllProductsAuction( CancellationToken cancellationToken);
        Task Create(AuctionDto auction, CancellationToken cancellationToken);
        Task Update(AuctionDto auction, CancellationToken cancellationToken);
    }
}
