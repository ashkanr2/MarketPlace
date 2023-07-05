using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.DtoModels;


namespace App.Domain.Core.DataAccess
{
    public interface IOrderRipository
    {
        Task<List<OrderDto>> GetAllBoothOrders(int BoothId, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAllOrders( CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAllUserOrders(int userId, CancellationToken cancellationToken);
        Task<OrderDto> GetDatail(int orderId, CancellationToken cancellationToken);
        Task<int> Create(OrderDto order, CancellationToken cancellationToken);
        Task Update(OrderDto order, CancellationToken cancellationToken);
        Task SoftDelete(int orderId, CancellationToken cancellationToken);
        Task HardDelted(int orderId, CancellationToken cancellationToken);
        Task CreateOrderProducts(int orderId, List<OrderProductDto> product, CancellationToken cancellationToken);

    }
}
