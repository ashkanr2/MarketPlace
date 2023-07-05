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
    public class OrderAppservice:IOrderAppservice
    {
        private readonly IOrderRipository _orderRipository;

        public OrderAppservice(IOrderRipository orderRipository)
        {
            _orderRipository = orderRipository;
        }

        public async Task<int> Create(OrderDto order, CancellationToken cancellationToken)
        => await _orderRipository.Create(order,cancellationToken);

       public async Task CreateOrderProducts(int orderId, List<OrderProductDto> product, CancellationToken cancellationToken)
        =>await _orderRipository.CreateOrderProducts(orderId, product, cancellationToken);

        public async Task<List<OrderDto>> GetAllBoothOrders(int BoothId, CancellationToken cancellationToken)
       => await _orderRipository.GetAllBoothOrders(BoothId, cancellationToken);


        public async Task<List<OrderDto>> GetAllOrders(CancellationToken cancellationToken)
        {
         var orders =  await _orderRipository.GetAllOrders(cancellationToken);
            return orders;
        }
        public async Task<List<OrderDto>> GetAllUserOrders(int userId, CancellationToken cancellationToken)
       =>await _orderRipository.GetAllUserOrders(userId, cancellationToken);

        public async Task<OrderDto> GetDatail(int orderId, CancellationToken cancellationToken)
        =>await _orderRipository.GetDatail(orderId, cancellationToken);

        public async Task HardDelted(int orderId, CancellationToken cancellationToken)
        =>await _orderRipository.HardDelted(orderId, cancellationToken);

        public async Task SoftDelete(int orderId, CancellationToken cancellationToken)
        =>await _orderRipository.SoftDelete(orderId, cancellationToken);

        public async Task Update(OrderDto order, CancellationToken cancellationToken)
        =>await _orderRipository.Update(order, cancellationToken);
    }
}
