using QLBanHang.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBanHang.Model;
using System.Data.Entity;

namespace QLBanHang.ImpleInterface
{
    public class ImpleCustomer : ICustomer
    {
        private Entities _context;

        public ImpleCustomer(Entities context)
        {
            _context = new Entities();
        }
        
        public void Insert(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Delete(int CustomerID)
        {
            try
            {
                Customer customer = _context.Customers.Find(CustomerID);
                _context.Customers.Remove(customer);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Update(Customer customer)
        {
            try
            {
                _context.Entry(customer).State = EntityState.Modified;
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

        public IEnumerable<Customer> GetCustomerByName(string name)
        {
            var customers = _context.Customers.Where(c => c.CustomeName == name).ToList();
            return customers;
        }

        public Customer GetCustomerByID(string id)
        {
            var customer = _context.Customers.Where(c => c.CustomerID == id).Single();
            if (customer != null)
            {
                return customer;
            }
            return null;
        }

        public IEnumerable<Customer> GetCustomerByAddress(string address)
        {
            var customers = _context.Customers.Where(c => c.Address.Contains(address)).ToList();
            return customers;
        }
    }
}
