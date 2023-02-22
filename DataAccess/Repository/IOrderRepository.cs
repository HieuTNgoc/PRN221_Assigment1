using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        public List<Order> ReadAll();
        public List<Order> ReadByMember(int memberId);

        public void Create(Order order);
        public void Update(int orderId, Order order);
        public void Delete(int orderId);
    }
}
