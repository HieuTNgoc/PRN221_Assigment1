using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private OrderDetailDAO _OrderDetailDAO;

        public OrderDetailRepository()
        {
            _OrderDetailDAO = new OrderDetailDAO();
        }

        public void Create(OrderDetail orderDetail)
        {
            _OrderDetailDAO.addNew(orderDetail);
        }

        public void Delete(int orderId, int productId)
        {
            _OrderDetailDAO.delete(orderId);
        }

        public List<OrderDetail> ReadAll()
        {
            return _OrderDetailDAO.getAll();
        }

        public List<OrderDetail> ReadByOrderList(List<Order> orderList)
        {
            return _OrderDetailDAO.getByOrderList(orderList);
        }

        public void Update(int orderId, int productId, OrderDetail orderDetail)
        {
            _OrderDetailDAO.update(orderId, orderDetail);
        }
    }
}
