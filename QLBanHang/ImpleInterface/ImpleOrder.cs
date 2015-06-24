using QLBanHang.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBanHang.Model;

namespace QLBanHang.ImpleInterface
{
    public class ImpleOrder : IOrder
    {
        private Entities _context;

        public ImpleOrder(Entities context)
        {
            _context = new Entities();
        }

        public void Insert(Order order)
        {
            try
            {
                _context.Orders.Add(order);
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
