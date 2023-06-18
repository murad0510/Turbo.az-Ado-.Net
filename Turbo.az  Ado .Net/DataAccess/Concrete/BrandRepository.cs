using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbo.az__Ado.Net.DataAccess.Abstractions;
using Turbo.az__Ado.Net.Entities;

namespace Turbo.az__Ado.Net.DataAccess.Concrete
{
    public class BrandRepository : IBrandRepository
    {
        private TurboContext _context;

        public BrandRepository()
        {
            _context = new TurboContext();
        }

        public void AddData(Brand data)
        {
            _context.Entry(data).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void DeleteData(Brand data)
        {
            _context.Entry(data).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public ObservableCollection<Brand> GetAll()
        {
            var result = from b in _context.Brands
                         select b;

            return new ObservableCollection<Brand>(result);
        }

        public Brand GetData(int id)
        {
            var result = _context.Brands.FirstOrDefault(b => b.Id == id);

            return result;
        }

        public void UpdateData(Brand data)
        {
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
