using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface ICartRipository
    {

        Task<CartDto> GetDatail(int cartId, CancellationToken cancellationToken);
        Task Create(CartDto cart, CancellationToken cancellationToken);
        Task<List<CartDto>> GetAll(CancellationToken cancellationToken);
        Task<List<CartDto>> GetAllUserCarts(int userID, CancellationToken cancellationToken);
        Task<List<CartDto>> GetAllBooth(int boothID , CancellationToken cancellationToken);
        Task Update(CartDto booth, CancellationToken cancellationToken);
        Task HardDelted(int cartId, CancellationToken cancellationToken);

    }
}
