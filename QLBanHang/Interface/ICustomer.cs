using QLBanHang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Interface
{
    public interface ICustomer
    {
        void Insert(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
        void Save();
        IEnumerable<Customer> GetCustomerByName(string name);
        Customer GetCustomerByID(string id);
        IEnumerable<Customer> GetCustomerByAddress(string address);
        IEnumerable<object> GetCustomerBuyMax();
    }
}
