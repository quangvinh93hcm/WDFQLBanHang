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
    public class ImpleCategory : ICategory
    {
        private Entities _context;

        public ImpleCategory(Entities context)
        {
            _context = new Entities();
        }

        public void Insert(Category category)
        {
            try
            {
                _context.Categories.Add(category);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Delete(int CategoryID)
        {
            try
            {
                Category category = _context.Categories.Find(CategoryID);
                _context.Categories.Remove(category);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Update(Category category)
        {
            try
            {
                _context.Entry(category).State = EntityState.Modified;
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
