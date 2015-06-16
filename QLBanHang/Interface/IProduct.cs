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
        Product GetProductByID(int id);
        IEnumerable<Product> GetProductByName(string name);
        IEnumerable<Product> GetProductByMinQuantity();
        void Insert(Product product);
        void Delete(int ProductID);
        void Update(Product product);
        void Save();
    }
}
