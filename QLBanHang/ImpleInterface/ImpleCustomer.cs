﻿using QLBanHang.Interface;
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
            if (customers.Count() > 0)
            {
                return customers;
            }
            return null;
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
            if (customers.Count() > 0)
            {
                return customers;
            }
            return null;
        }

        public IEnumerable<object> GetCustomerBuyMax()
        {
            var customers = from customer in _context.Customers
                            join order in _context.Orders
                            on customer.CustomerID equals order.CustomerID
                            group new { customer, order } by new
                         {
                             customer.CustomerID,
                             customer.CustomeName,
                             customer.Address,
                             customer.Phone,
                             order.DateOrder,
                             order.State,
                             order.PaymentTo
                         } into resultSet
                            select new
                            {
                                CustomerID = resultSet.Key.CustomerID,
                                CustomerName = resultSet.Key.CustomeName,
                                Address = resultSet.Key.Address,
                                Phone = resultSet.Key.Phone,
                                DateOrder = resultSet.Key.DateOrder,
                                State = resultSet.Key.State,
                                TypePayment = resultSet.Key.PaymentTo,
                                Total = resultSet.Count()
                            };
            var customerByMax = customers.Where(c => !customers.Any(m => m.CustomerID == c.CustomerID && m.Total > c.Total)).ToList();
            return customerByMax;
        }
    }
}
