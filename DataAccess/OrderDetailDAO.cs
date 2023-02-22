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

    }
}
