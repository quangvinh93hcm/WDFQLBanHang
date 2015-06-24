using QLBanHang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Interface
{
    public interface IOrder
    {
        void Insert(Order order);
        /*IEnumerable<Order> GetOrderByID();
        IEnumerable<Order> GetOrderByDate();
        IEnumerable<Order> GetOrderByEmployeeID(string id);*/
        void Save();
    }
}
