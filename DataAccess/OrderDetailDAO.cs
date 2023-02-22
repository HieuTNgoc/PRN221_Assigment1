using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private Asm1PRNContext _Context;

        public OrderDetailDAO()
        {
            _Context = DataProvider.Ins.DB;
        }

        public List<OrderDetail> getAll()
        {
            return _Context.OrderDetails.ToList();
        }

        public List<OrderDetail> getByOrderList(List<Order> orderList)
        {
            var list = new List<OrderDetail>();
            foreach (var order in orderList)
            {
                var detail = _Context.OrderDetails.Where(x => x.OrderId == order.OrderId).ToList();
                if (detail.Count > 0)
                {
                    list.Add(detail[0]);
                }
            }
            return list;
        }

        public void addNew(OrderDetail orderDetail)
        {
            try
            {
                _Context.OrderDetails.Add(orderDetail);
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void update(int orderId, OrderDetail orderDetail)
        {
            try
            {
                var ord = _Context.OrderDetails.Where(x => x.OrderId == orderId).SingleOrDefault();
                if (ord == null)
                {
                    throw new Exception("Can not read selected Order Detail!");
                }
                ord.OrderId = orderId;
                ord.ProductId = orderDetail.ProductId;
                ord.UnitPrice = orderDetail.UnitPrice;
                ord.Quantity = orderDetail.Quantity;
                ord.Discount = orderDetail.Discount;
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
                var ord = _Context.OrderDetails.Where(x => x.OrderId == orderId).SingleOrDefault();
                if (ord == null)
                {
                    throw new Exception("Can not read selected Order Detail!");
                }
                _Context.OrderDetails.Remove(ord);
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
