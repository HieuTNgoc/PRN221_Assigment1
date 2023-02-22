using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        public List<OrderDetail> ReadAll();
        public List<OrderDetail> ReadByOrderList(List<Order> orderList);

        public void Create(OrderDetail orderDetail);
        public void Update(int orderId, int productId, OrderDetail orderDetail);
        public void Delete(int orderId, int productId);
    }
}
