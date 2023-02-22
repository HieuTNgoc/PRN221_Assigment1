using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private OrderDAO _OrderDAO;

        public OrderRepository()
        {
            _OrderDAO = new OrderDAO();
        }

        public void Create(Order order)
        {
            _OrderDAO.addNew(order);
        }

        public void Delete(int orderId)
        {
            _OrderDAO.delete(orderId);
        }


        public void Update(int orderId, Order order)
        {
            _OrderDAO.update(orderId, order);
        }
        public List<Order> ReadAll()
        {
            return _OrderDAO.getAll();
        }

        public List<Order> ReadByMember(int memberId)
        {
            return _OrderDAO.getByMember(memberId);
        }
    }
}
