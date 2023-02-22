using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        private Asm1PRNContext _Context;

        public OrderDAO()
        {
            _Context = DataProvider.Ins.DB;
        }

        public List<Order> getAll()
        {
            return _Context.Orders.ToList();
        }

        public void addNew(Order order)
        {
            try
            {
                _Context.Orders.Add(order);
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void update(int orderId, Order order)
        {
            try
            {
                var ord = _Context.Orders.Where(x => x.OrderId == orderId).SingleOrDefault();
                if (ord == null)
                {
                    throw new Exception("Can not read selected Order!");
                }
                ord.MemberId = orderId;
                ord.RequireDate = order.RequireDate;
                ord.OrderDate = order.OrderDate;
                ord.ShippedDate = order.ShippedDate;
                ord.Freight = order.Freight;
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void delete(int orderId)
        {
            try
            {
                var ord = _Context.Orders.Where(x => x.OrderId == orderId).SingleOrDefault();
                if (ord == null)
                {
                    throw new Exception("Can not read selected Order!");
                }
                _Context.Orders.Remove(ord);
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Order> getByMember(int memberId)
        {
            return _Context.Orders.Where(x => x.MemberId == memberId).ToList();

        }
    }
}
