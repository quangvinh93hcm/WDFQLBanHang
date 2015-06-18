using QLBanHang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Interface
{
    public interface IEmployee
    {
        Employee GetEmployeeByID(int id);
        IEnumerable<Employee> GetEmployeeByName(string name);
        void Insert(Employee employee);
        void Delete(int id);
        void Update(Employee employee);
        void Save();
    }
}
