using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBanHang.Interface;
using QLBanHang.Model;
using System.Data.Entity;

namespace QLBanHang.ImpleInterface
{
    public class ImpleIProduct : IProduct
    {
        private Entities _context;

        public ImpleIProduct(Entities context)
        {
            _context = new Entities();
        }

        public Product GetProductByID(string id)
        {
            var Product = _context.Products.Where(p => p.ProductID == id).Single();
            if (Product == null)
            {
                return null;
            }
            return Product;
        }

        public IEnumerable<Product> GetProductByName(string name)
        {
            var product = _context.Products.Where(p => p.ProductName == name).ToList();
            return product;
        }

        public IEnumerable<Product> GetProductByMinQuantity()
        {
            var product = _context.Products.Where(p => p.Quantity < 10).ToList();
            return product;
        }

        public IEnumerable<object> GetHotProduct()
        {
            var items = (from product in _context.Products
                         join detail in _context.Order_Details
                         on product.ProductID equals detail.ProductID
                         group new { product, detail } by new
                         {
                             product.ProductID,
                             product.ProductName,
                             product.Supplier.SupplierName,
                             product.Category.TypeName
                         } into resultSet
                         select new
                         {
                             ProductID = resultSet.Key.ProductID,
                             ProductName = resultSet.Key.ProductName,
                             SupplierName = resultSet.Key.SupplierName,
                             CategoryName = resultSet.Key.TypeName,
                             Quantity = resultSet.Sum(a => a.detail.Quantity),
                             Total = resultSet.Sum(a => a.detail.Total)
                         }).ToList();
            return items;
        }

        public void Insert(Product product)
        {
            try
            {
                _context.Products.Add(product);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Delete(int ProductID)
        {
            try
            {
                Product product = _context.Products.Find(ProductID);
                _context.Products.Remove(product);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Update(Product product)
        {
            try
            {
                _context.Entry(product).State = EntityState.Modified;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
