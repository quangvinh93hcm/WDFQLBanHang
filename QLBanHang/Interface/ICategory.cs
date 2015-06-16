using QLBanHang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Interface
{
    public interface ICategory
    {
        void Insert(Category category);
        void Delete(int id);
        void Update(Category category);
        void Save();
    }
}
