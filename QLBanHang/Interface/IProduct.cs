using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBanHang.Model;

namespace QLBanHang.Interface
{
    public interface IProduct
    {
        Product GetProductByID(string id);
        IEnumerable<Product> GetProductByName(string name);
        IEnumerable<Product> GetProductByMinQuantity();
        IEnumerable<object> GetHotProduct();
        IEnumerable<object> GetProductByMaxTotal();
        void Insert(Product product);
        void Delete(string ProductID);
        void Update(Product product);
        void Save();
    }
}
