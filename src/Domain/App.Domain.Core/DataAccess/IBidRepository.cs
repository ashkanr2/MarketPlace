using App.Domain.Core.DtoModels;

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace App.Domain.Core.DataAccess
{
    public interface IBidRepository
    {
       
        Task<List<BidDto>> GetAll(int ProductId, CancellationToken cancellationToken);
        Task<List<BidDto>> GetUserBids(int userID, CancellationToken cancellationToken);
        Task<BidDto> GetDatail(int bidId, CancellationToken cancellationToken);
        Task Create(BidDto bid, CancellationToken cancellationToken);
        Task SoftDelete(int bidId, CancellationToken cancellationToken);
        Task HardDelted(int bidId, CancellationToken cancellationToken);

    }
}
