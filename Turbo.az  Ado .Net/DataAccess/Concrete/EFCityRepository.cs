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
    public class EFCityRepository : ICityRepository
    {
        private TurboContext _context;

        public EFCityRepository()
        {
            _context = new TurboContext();
        }
        public void AddData(City data)
        {
            _context.Entry(data).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void DeleteData(City data)
        {
            _context.Entry(data).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public ObservableCollection<City> GetAll()
        {
            var result = from b in _context.Cities
                         select b;

            return new ObservableCollection<City>(result);
        }

        public City GetData(int id)
        {
            var result = _context.Cities.FirstOrDefault(b => b.Id == id);

            return result;
        }

        public void UpdateData(City data)
        {
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
