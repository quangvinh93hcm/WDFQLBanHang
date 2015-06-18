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
    public class ImpleEmployee : IEmployee
    {
        private Entities _context;

        public ImpleEmployee(Entities context)
        {
            _context = new Entities();
        }

        public Employee GetProductByID(string id)
        {
            var employee = _context.Employees.Where(p => p.Id == id).Single();
            if (employee == null)
            {
                return null;
            }
            return employee;
        }

        public IEnumerable<Employee> GetProductByName(string name)
        {
            var items = _context.Employees.Where(p => p.Name == name).ToList();
            if (items.Count() > 0)
            {
                return items;
            }
            return null;
        }

        public void Insert(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
            }
            catch (Exception)
            {

                throw;
            }

        }
        
        public void Delete(int ID)
        {
            try
            {
                Employee employee = _context.Employees.Find(ID);
                _context.Employees.Remove(employee);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Update(Employee employee)
        {
            try
            {
                _context.Entry(employee).State = EntityState.Modified;
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
